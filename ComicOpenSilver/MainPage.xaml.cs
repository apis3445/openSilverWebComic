using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Printing;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace comic;

public partial class MainPage : UserControl
{
    private List<cFigura> lNubes;

    private int iTotalNubes;

    private int iHijoActual;

    public static int iNubeActual;

    public MainPage()
    {
        lNubes = new List<cFigura>();
        iTotalNubes = -1;
        iHijoActual = 7;
        InitializeComponent();
        this.Loaded += OnPageLoaded;
        canvasComic.MouseLeftButtonUp += Canvas2_MouseLeftButtonUp;
        canvasComic.MouseMove += Canvas2_MouseMove;
        canvasComic.MouseLeftButtonDown += Canvas2_MouseLeftButtonDown;
        bBorrar.Click += bBorrar_Click;
        bGlobo.Click += bGlobo_Click;
        bImprimir.Click += bImprimir_Click;
        cbFiguras.SelectionChanged += ComboBox1_SelectionChanged;
        bNubeDer.Click += bNubeDer_Click;
        bOvaloIzq.Click += bOvaloIzq_Click;
        bOvaloDer.Click += bOvaloDer_Click;
        bCuadroIzq.Click += bCuadroIzq_Click;
        bCuadroDer.Click += bCuadroDer_Click;
        bCuadro.Click += bCuadro_Click;
        bGuardar.Click += bGuardar_Click;
        bAbrir.Click += bAbrir_Click;
        bNuevo.Click += bNuevo_Click;
    }

    private void OnPageLoaded(object sender, RoutedEventArgs e)
    {
        SetupFileDragAndDrop();
        SetupPanelClickHandlers();
    }

    private void SetupFileDragAndDrop()
    {
        // Attach to document so no UIElement→DOM marshalling is needed.
        // Coordinates are made relative to #opensilver-root so they match
        // the coordinate space returned by TransformToVisual.
        Action<string> onDrop = HandleJsDrop;
        OpenSilver.Interop.ExecuteJavaScript(@"
            function _comicOverPanel(clientX, clientY) {
                var bounds = window._comicPanelBounds || [];
                var root = document.getElementById('opensilver-root');
                var rect = root ? root.getBoundingClientRect() : {left:0, top:0};
                var x = clientX - rect.left, y = clientY - rect.top;
                for (var i = 0; i < bounds.length; i++) {
                    var b = bounds[i];
                    if (b.w > 0 && x >= b.x && x <= b.x + b.w && y >= b.y && y <= b.y + b.h) return true;
                }
                return false;
            }
            document.addEventListener('dragover', function(e) {
                if (_comicOverPanel(e.clientX, e.clientY)) e.preventDefault();
            });
            document.addEventListener('drop', function(e) {
                if (!_comicOverPanel(e.clientX, e.clientY)) return;
                e.preventDefault();
                var files = e.dataTransfer && e.dataTransfer.files;
                if (!files || files.length === 0) return;
                var file = files[0];
                if (!file.type.match('image.*')) return;
                var reader = new FileReader();
                reader.onload = function(ev) {
                    var root = document.getElementById('opensilver-root');
                    var rect = root ? root.getBoundingClientRect() : {left:0, top:0};
                    $0(ev.target.result + '|' + (e.clientX - rect.left) + '|' + (e.clientY - rect.top));
                };
                reader.readAsDataURL(file);
            });
        ", onDrop);
    }

    private void HandleJsDrop(string payload)
    {
        var p1 = payload.IndexOf('|');
        if (p1 < 0) return;
        var dataUrl = payload.Substring(0, p1);
        var rest = payload.Substring(p1 + 1);
        var p2 = rest.IndexOf('|');
        if (p2 < 0) return;
        if (!double.TryParse(rest.Substring(0, p2), System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture, out double x)) return;
        if (!double.TryParse(rest.Substring(p2 + 1), System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture, out double y)) return;
        Dispatcher.BeginInvoke(() => DropImageAt(dataUrl, x, y));
    }

    private void DropImageAt(string dataUrl, double x, double y)
    {
        var panels = new Canvas[] { canvasCuadro1, canvasCuadro2, canvasCuadro3, canvasCuadro4, canvasCuadro5, canvasCuadro6 };
        var root = Application.Current.RootVisual as UIElement;
        foreach (var panel in panels)
        {
            try
            {
                var transform = panel.TransformToVisual(root);
                var tl = transform.Transform(new Point(0, 0));
                var w = panel.ActualWidth > 0 ? panel.ActualWidth : panel.Width;
                var h = panel.ActualHeight > 0 ? panel.ActualHeight : panel.Height;
                if (x >= tl.X && x <= tl.X + w && y >= tl.Y && y <= tl.Y + h)
                {
                    LoadDroppedImage(panel, dataUrl);
                    return;
                }
            }
            catch { }
        }
    }

    private void SetupPanelClickHandlers()
    {
        var panels = new Canvas[] { canvasCuadro1, canvasCuadro2, canvasCuadro3, canvasCuadro4, canvasCuadro5, canvasCuadro6 };

        Action<string> onFilePicked = (payload) =>
        {
            var sep = payload.IndexOf('|');
            if (sep < 0 || !int.TryParse(payload.Substring(0, sep), out int idx)) return;
            if (idx < 0 || idx >= panels.Length) return;
            var dataUrl = payload.Substring(sep + 1);
            var panel = panels[idx];
            Dispatcher.BeginInvoke(() => LoadDroppedImage(panel, dataUrl));
        };

        // Bounds start empty; RefreshPanelBoundsInJs fills them once layout is complete.
        OpenSilver.Interop.ExecuteJavaScript(@"
            window._comicPanelBounds = [];
            window._comicPanelCb = $0;
            var _mdX = 0, _mdY = 0;
            document.addEventListener('mousedown', function(e) { _mdX = e.clientX; _mdY = e.clientY; });
            document.addEventListener('click', function(e) {
                if (window._comicFigureClick) { window._comicFigureClick = false; return; }
                var dx = e.clientX - _mdX, dy = e.clientY - _mdY;
                if (dx * dx + dy * dy > 25) return;
                var bounds = window._comicPanelBounds;
                var root = document.getElementById('opensilver-root');
                var rect = root ? root.getBoundingClientRect() : {left:0,top:0};
                var x = e.clientX - rect.left;
                var y = e.clientY - rect.top;
                for (var i = 0; i < bounds.length; i++) {
                    var b = bounds[i];
                    if (b.w > 0 && x >= b.x && x <= b.x + b.w && y >= b.y && y <= b.y + b.h) {
                        (function(idx) {
                            var input = document.createElement('input');
                            input.type = 'file';
                            input.accept = 'image/*';
                            input.onchange = function(ev) {
                                var file = ev.target.files[0];
                                if (!file) return;
                                var reader = new FileReader();
                                reader.onload = function(re) { window._comicPanelCb(idx + '|' + re.target.result); };
                                reader.readAsDataURL(file);
                            };
                            input.click();
                        })(i);
                        break;
                    }
                }
            });
        ", onFilePicked);

        // Can't compute bounds at Loaded time — layout isn't done yet.
        // SizeChanged fires after the first layout pass when ActualWidth/Height are set.
        canvasComic.SizeChanged += OnCanvasComicSizeChanged;
    }

    private void OnCanvasComicSizeChanged(object sender, SizeChangedEventArgs e)
    {
        canvasComic.SizeChanged -= OnCanvasComicSizeChanged;
        RefreshPanelBoundsInJs();
    }

    private void RefreshPanelBoundsInJs()
    {
        var panels = new Canvas[] { canvasCuadro1, canvasCuadro2, canvasCuadro3, canvasCuadro4, canvasCuadro5, canvasCuadro6 };
        var root = Application.Current.RootVisual as UIElement;
        var ic = System.Globalization.CultureInfo.InvariantCulture;
        var sb = new System.Text.StringBuilder("[");
        for (int i = 0; i < panels.Length; i++)
        {
            double x = 0, y = 0, w = 0, h = 0;
            try
            {
                var t = panels[i].TransformToVisual(root);
                var tl = t.Transform(new Point(0, 0));
                x = tl.X; y = tl.Y;
                w = panels[i].ActualWidth > 0 ? panels[i].ActualWidth : panels[i].Width;
                h = panels[i].ActualHeight > 0 ? panels[i].ActualHeight : panels[i].Height;
            }
            catch { }
            sb.Append($"{{x:{x.ToString(ic)},y:{y.ToString(ic)},w:{w.ToString(ic)},h:{h.ToString(ic)}}}");
            if (i < panels.Length - 1) sb.Append(",");
        }
        sb.Append("]");
        OpenSilver.Interop.ExecuteJavaScript("window._comicPanelBounds = " + sb + ";");
    }

    private static void LoadDroppedImage(Canvas canvas, string dataUrl)
    {
        var commaIndex = dataUrl.IndexOf(',');
        if (commaIndex < 0) return;
        byte[] bytes;
        try { bytes = Convert.FromBase64String(dataUrl.Substring(commaIndex + 1)); }
        catch { return; }

        var bitmap = new BitmapImage();
        bitmap.SetSource(new MemoryStream(bytes));

        canvas.Children.Clear();
        var image = new Image
        {
            Width = canvas.Width,
            Height = canvas.Height,
            Stretch = Stretch.Fill,
            Source = bitmap
        };
        Canvas.SetLeft(image, 0);
        Canvas.SetTop(image, 0);
        canvas.Children.Add(image);
    }

    private void Canvas_Drop(object sender, DragEventArgs e)
    {
        IDataObject data = e.Data;
        Point position = e.GetPosition((UIElement)sender);
        if (!data.GetDataPresent(DataFormats.FileDrop))
        {
            return;
        }
        FileInfo[] array = (FileInfo[])data.GetData(DataFormats.FileDrop);
        if (array.Length <= 0)
        {
            return;
        }
        NewLateBinding.LateCall(NewLateBinding.LateGet(sender, null, "Children", new object[0], null, null, null), null, "Clear", new object[0], null, null, null, IgnoreReturn: true);
        if ((Operators.CompareString(array[0].Extension, ".jpg", TextCompare: false) == 0) | (Operators.CompareString(array[0].Extension, ".JPG", TextCompare: false) == 0) | (Operators.CompareString(array[0].Extension, ".PNG", TextCompare: false) == 0) | (Operators.CompareString(array[0].Extension, ".png", TextCompare: false) == 0) | (Operators.CompareString(array[0].Extension, ".GIF", TextCompare: false) == 0) | (Operators.CompareString(array[0].Extension, ".gif", TextCompare: false) == 0))
        {
            BitmapImage val = new BitmapImage();
            ((BitmapSource)val).SetSource((Stream)array[0].OpenRead());
            Image val2 = new Image();
            position.Y = 0.0;
            position.X = 0.0;
            val2.Width = Conversions.ToDouble(NewLateBinding.LateGet(sender, null, "Width", new object[0], null, null, null));
            val2.Height = Conversions.ToDouble(NewLateBinding.LateGet(sender, null, "Height", new object[0], null, null, null));
            val2.Source = val;
            val2.SetValue(Canvas.TopProperty, (object)position.Y);
            val2.SetValue(Canvas.LeftProperty, (object)position.X);
            val2.Stretch = Stretch.Fill;
            object instance = NewLateBinding.LateGet(sender, null, "Children", new object[0], null, null, null);
            object[] array2 = new object[1] { val2 };
            bool[] array3 = new bool[1] { true };
            NewLateBinding.LateCall(instance, null, "Add", array2, null, null, array3, IgnoreReturn: true);
            if (array3[0])
            {
                val2 = (Image)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(Image));
            }
        }
    }

    private void Canvas2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Point position = e.GetPosition(canvasComic);
        if (lNubes.Count > 0)
        {
            lNubes[iNubeActual].iAux = 1;
            lNubes[iNubeActual].SetPosicion(position);
        }
    }

    private void Canvas2_MouseMove(object sender, MouseEventArgs e)
    {
        if (lNubes.Count > 0 && lNubes[iNubeActual].iAux == 1)
        {
            Point position = e.GetPosition(canvasComic);
            if (position.Y + lNubes[iNubeActual].newImage.Height < canvasComic.Height &&
                position.X + lNubes[iNubeActual].newImage.Width < canvasComic.Width)
            {
                lNubes[iNubeActual].SetPosicion(position);
            }
        }
    }

    private void Canvas2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (lNubes.Count > 0)
        {
            lNubes[iNubeActual].iAux = 0;
        }
    }

    private object AnonymousMethod5(object s, object args)
    {
        return null;
    }

    private object AnonymousMethod6(object s, object args, Canvas dynamicPanel)
    {
        NewLateBinding.LateSet(args, null, "PageVisual", new object[1] { dynamicPanel }, null, null);
        return null;
    }

    private object AnonymousMethod7(object s, object args, Canvas dynamicPanel)
    {
        dynamicPanel = null;
        return null;
    }

    private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        iNubeActual = cbFiguras.SelectedIndex;
    }

    private void bGlobo_Click(object sender, RoutedEventArgs e)
    {
        GuardaFigura(1, "Nube Izquierda");
    }

    private void bNubeDer_Click(object sender, RoutedEventArgs e)
    {
        GuardaFigura(2, "Nube Derecha");
    }

    private void GuardaFigura(int iFigura, string sFigura)
    {
        Point dropPoint = default(Point);
        dropPoint.X = 0.0;
        dropPoint.Y = 0.0;
        checked
        {
            iTotalNubes++;
            int num = iTotalNubes + 1;
            iNubeActual = iTotalNubes;
            cFigura cFigura2 = new cFigura();
            cbFiguras.Items.Add(sFigura + num);
            cFigura2.SetImagen(tbTexto.Text, dropPoint, iFigura, iNubeActual);
            cFigura2.iHijo = canvasComic.Children.Count + 1;
            lNubes.Add(cFigura2);
            canvasComic.Children.Add(lNubes[cFigura2.iNumero].newImage);
            canvasComic.Children.Add(lNubes[cFigura2.iNumero].tb);
            tbTexto.Text = "";
        }
    }

    private void GuardaFigura(int iFigura, string sFigura, Point pPoint)
    {
        Point dropPoint = default(Point);
        dropPoint.X = pPoint.X;
        dropPoint.Y = pPoint.Y;
        checked
        {
            iTotalNubes++;
            int num = iTotalNubes + 1;
            iNubeActual = iTotalNubes;
            cFigura cFigura2 = new cFigura();
            cbFiguras.Items.Add(sFigura + num);
            cFigura2.SetImagen(tbTexto.Text, dropPoint, iFigura, iNubeActual);
            cFigura2.iHijo = canvasComic.Children.Count + 1;
            lNubes.Add(cFigura2);
            canvasComic.Children.Add(lNubes[cFigura2.iNumero].newImage);
            canvasComic.Children.Add(lNubes[cFigura2.iNumero].tb);
            tbTexto.Text = "";
        }
    }

    private void bOvaloIzq_Click(object sender, RoutedEventArgs e)
    {
        GuardaFigura(3, "Óvalo Izquierda");
    }

    private void bOvaloDer_Click(object sender, RoutedEventArgs e)
    {
        GuardaFigura(4, "Óvalo Derecha");
    }

    private void bCuadroIzq_Click(object sender, RoutedEventArgs e)
    {
        GuardaFigura(5, "Cuadro Izquierda");
    }

    private void bCuadroDer_Click(object sender, RoutedEventArgs e)
    {
        GuardaFigura(6, "Cuadro Derecha");
    }

    private void bCuadro_Click(object sender, RoutedEventArgs e)
    {
        GuardaFigura(7, "Cuadro");
    }

    private void bBorrar_Click(object sender, RoutedEventArgs e)
    {
        canvasComic.Children.RemoveAt(lNubes[iNubeActual].iHijo);
        checked
        {
            canvasComic.Children.RemoveAt(lNubes[iNubeActual].iHijo - 1);
            lNubes.RemoveAt(iNubeActual);
            cbFiguras.Items.RemoveAt(iNubeActual);
            if (iNubeActual > 0)
            {
                iNubeActual--;
            }
            if (iTotalNubes >= 0)
            {
                iTotalNubes--;
            }
        }
    }

    private void bGuardar_Click(object sender, RoutedEventArgs e)
    {
        Guarda();
    }

    private void Guarda()
    {
        using var ms = new MemoryStream();
        var settings = new XmlWriterSettings { Indent = true, Encoding = new System.Text.UTF8Encoding(false), OmitXmlDeclaration = true };
        var writer = XmlWriter.Create(ms, settings);
        try
        {
            writer.WriteComment("Web Comic");
            writer.WriteStartElement("figuras");
            int num = lNubes.Count - 1;
            for (int i = 0; i <= num; i++)
            {
                writer.WriteStartElement("globo");
                writer.WriteElementString("X", lNubes[i].Punto.X.ToString());
                writer.WriteElementString("Y", lNubes[i].Punto.Y.ToString());
                writer.WriteElementString("Tipo", lNubes[i].iTipo.ToString());
                writer.WriteElementString("Texto", lNubes[i].tb.Text);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
        }
        finally
        {
            ((IDisposable)writer)?.Dispose();
        }
        var xml = Encoding.UTF8.GetString(ms.ToArray());
        OpenSilver.Interop.ExecuteJavaScript("localStorage.setItem('WebComic', $0);", xml);
    }

    private void bAbrir_Click(object sender, RoutedEventArgs e)
    {
        var stored = OpenSilver.Interop.ExecuteJavaScript("localStorage.getItem('WebComic')");
        if (stored == null) return;
        string s = stored.ToString();
        if (string.IsNullOrEmpty(s) || s == "null") return;

        // Clear existing figure children (panels + borders occupy indices 0–11)
        int childIdx = canvasComic.Children.Count - 1;
        while (childIdx >= 12)
        {
            canvasComic.Children.RemoveAt(childIdx);
            childIdx--;
        }
        cbFiguras.Items.Clear();

        int iTipo = 0;
        Point val3 = default(Point);
        XmlReader reader = XmlReader.Create((TextReader)new StringReader(s));
        try
        {
            lNubes.Clear();
            iNubeActual = 0;
            iTotalNubes = -1;
            iHijoActual = 7;
            while (reader.Read())
            {
                if (reader.NodeType != System.Xml.XmlNodeType.Element) continue;
                switch (reader.Name)
                {
                    case "X":
                        if (reader.Read()) { val3.X = Conversions.ToDouble(reader.Value); }
                        break;
                    case "Y":
                        if (reader.Read()) { val3.Y = Conversions.ToDouble(reader.Value); }
                        break;
                    case "Tipo":
                        if (reader.Read()) { iTipo = Conversions.ToInteger(reader.Value); }
                        break;
                    case "Texto":
                        if (reader.Read())
                        {
                            tbTexto.Text = reader.Value;
                            GuardaFigura(iTipo, "Figura", val3);
                            lNubes[iNubeActual].SetPosicion(val3);
                            tbTexto.Text = "";
                        }
                        break;
                }
            }
        }
        catch { }
        finally
        {
            ((IDisposable)reader)?.Dispose();
        }
    }

    private void bNuevo_Click(object sender, RoutedEventArgs e)
    {
        checked
        {
            int num = canvasComic.Children.Count - 1;
            while (num >= 12)
            {
                canvasComic.Children.RemoveAt(num);
                num--;
            }
            if (canvasCuadro1.Children.Count > 0) canvasCuadro1.Children.RemoveAt(0);
            if (canvasCuadro2.Children.Count > 0) canvasCuadro2.Children.RemoveAt(0);
            if (canvasCuadro3.Children.Count > 0) canvasCuadro3.Children.RemoveAt(0);
            if (canvasCuadro4.Children.Count > 0) canvasCuadro4.Children.RemoveAt(0);
            if (canvasCuadro5.Children.Count > 0) canvasCuadro5.Children.RemoveAt(0);
            if (canvasCuadro6.Children.Count > 0) canvasCuadro6.Children.RemoveAt(0);
            cbFiguras.Items.Clear();
            iHijoActual = 7;
            iNubeActual = 0;
            iTotalNubes = -1;
            lNubes.Clear();
        }
    }

    private void bImprimir_Click(object sender, RoutedEventArgs e)
    {
        Canvas val = new Canvas();
        val.Width = 760.0;
        checked
        {
            int num = lNubes.Count - 1;
            Point dropPoint = default(Point);
            for (int i = 0; i <= num; i++)
            {
                cFigura cFigura2 = new cFigura();
                dropPoint.Y = lNubes[i].Punto.Y;
                dropPoint.X = lNubes[i].Punto.X;
                cFigura2.SetImagen(lNubes[i].tb.Text, dropPoint, lNubes[i].iTipo, i);
                val.Children.Add(cFigura2.newImage);
                val.Children.Add(cFigura2.tb);
            }
            PrintDocument val2 = new PrintDocument();
            val2.BeginPrint += (object s, BeginPrintEventArgs args) =>
            {
                AnonymousMethod5(s, args);
            };
            val2.PrintPage += (object s, PrintPageEventArgs args) =>
            {
                AnonymousMethod6(s, args, canvasComic);
            };
            val2.EndPrint += (object s, EndPrintEventArgs args) =>
            {
                AnonymousMethod7(s, args, canvasComic);
            };
            val2.Print("Printing Comic");
        }
    }

}

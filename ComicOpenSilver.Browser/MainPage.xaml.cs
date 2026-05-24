using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Printing;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace comic;

[DesignerGenerated]
public class MainPage : UserControl
{
	private List<cFigura> lNubes;

	private List<cFigura> lGlobos_Imprimir;

	private int iTotalNubes;

	private int iHijoActual;

	public static int iNubeActual;

	private int iFigura;

	private int[] iTipos;

	[AccessedThroughProperty("canvasComic")]
	private Canvas _canvasComic;

	[AccessedThroughProperty("canvasCuadro1")]
	private Canvas _canvasCuadro1;

	[AccessedThroughProperty("canvasCuadro4")]
	private Canvas _canvasCuadro4;

	[AccessedThroughProperty("canvasCuadro2")]
	private Canvas _canvasCuadro2;

	[AccessedThroughProperty("canvasCuadro3")]
	private Canvas _canvasCuadro3;

	[AccessedThroughProperty("canvasCuadro5")]
	private Canvas _canvasCuadro5;

	[AccessedThroughProperty("canvasCuadro6")]
	private Canvas _canvasCuadro6;

	[AccessedThroughProperty("Border1")]
	private Border _Border1;

	[AccessedThroughProperty("Border2")]
	private Border _Border2;

	[AccessedThroughProperty("Border3")]
	private Border _Border3;

	[AccessedThroughProperty("Border4")]
	private Border _Border4;

	[AccessedThroughProperty("Border5")]
	private Border _Border5;

	[AccessedThroughProperty("Border6")]
	private Border _Border6;

	[AccessedThroughProperty("bBorrar")]
	private Button _bBorrar;

	[AccessedThroughProperty("tbTexto")]
	private TextBox _tbTexto;

	[AccessedThroughProperty("bGlobo")]
	private Button _bGlobo;

	[AccessedThroughProperty("bImprimir")]
	private Button _bImprimir;

	[AccessedThroughProperty("cbFiguras")]
	private ComboBox _cbFiguras;

	[AccessedThroughProperty("TextBlock1")]
	private TextBlock _TextBlock1;

	[AccessedThroughProperty("TextBlock2")]
	private TextBlock _TextBlock2;

	[AccessedThroughProperty("bNubeDer")]
	private Button _bNubeDer;

	[AccessedThroughProperty("bOvaloIzq")]
	private Button _bOvaloIzq;

	[AccessedThroughProperty("bOvaloDer")]
	private Button _bOvaloDer;

	[AccessedThroughProperty("bCuadroIzq")]
	private Button _bCuadroIzq;

	[AccessedThroughProperty("bCuadroDer")]
	private Button _bCuadroDer;

	[AccessedThroughProperty("bCuadro")]
	private Button _bCuadro;

	[AccessedThroughProperty("bGuardar")]
	private Button _bGuardar;

	[AccessedThroughProperty("TextBlock3")]
	private TextBlock _TextBlock3;

	[AccessedThroughProperty("bAbrir")]
	private Button _bAbrir;

	[AccessedThroughProperty("bNuevo")]
	private Button _bNuevo;

	private bool _contentLoaded;

	internal virtual Canvas canvasComic
	{
		[DebuggerNonUserCode]
		get
		{
			return _canvasComic;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			MouseButtonEventHandler val = new MouseButtonEventHandler(Canvas2_MouseLeftButtonUp);
			MouseEventHandler val2 = new MouseEventHandler(Canvas2_MouseMove);
			MouseButtonEventHandler val3 = new MouseButtonEventHandler(Canvas2_MouseLeftButtonDown);
			if (_canvasComic != null)
			{
				_canvasComic.MouseLeftButtonUp -= val;
				_canvasComic.MouseMove -= val2;
				_canvasComic.MouseLeftButtonDown -= val3;
			}
			_canvasComic = value;
			if (_canvasComic != null)
			{
				_canvasComic.MouseLeftButtonUp += val;
				_canvasComic.MouseMove += val2;
				_canvasComic.MouseLeftButtonDown += val3;
			}
		}
	}

	internal virtual Canvas canvasCuadro1
	{
		[DebuggerNonUserCode]
		get
		{
			return _canvasCuadro1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			DragEventHandler val = new DragEventHandler(Canvas_Drop);
			if (_canvasCuadro1 != null)
			{
				_canvasCuadro1.Drop -= val;
			}
			_canvasCuadro1 = value;
			if (_canvasCuadro1 != null)
			{
				_canvasCuadro1.Drop += val;
			}
		}
	}

	internal virtual Canvas canvasCuadro4
	{
		[DebuggerNonUserCode]
		get
		{
			return _canvasCuadro4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			DragEventHandler val = new DragEventHandler(Canvas_Drop);
			if (_canvasCuadro4 != null)
			{
				_canvasCuadro4.Drop -= val;
			}
			_canvasCuadro4 = value;
			if (_canvasCuadro4 != null)
			{
				_canvasCuadro4.Drop += val;
			}
		}
	}

	internal virtual Canvas canvasCuadro2
	{
		[DebuggerNonUserCode]
		get
		{
			return _canvasCuadro2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			DragEventHandler val = new DragEventHandler(Canvas_Drop);
			if (_canvasCuadro2 != null)
			{
				_canvasCuadro2.Drop -= val;
			}
			_canvasCuadro2 = value;
			if (_canvasCuadro2 != null)
			{
				_canvasCuadro2.Drop += val;
			}
		}
	}

	internal virtual Canvas canvasCuadro3
	{
		[DebuggerNonUserCode]
		get
		{
			return _canvasCuadro3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			DragEventHandler val = new DragEventHandler(Canvas_Drop);
			if (_canvasCuadro3 != null)
			{
				_canvasCuadro3.Drop -= val;
			}
			_canvasCuadro3 = value;
			if (_canvasCuadro3 != null)
			{
				_canvasCuadro3.Drop += val;
			}
		}
	}

	internal virtual Canvas canvasCuadro5
	{
		[DebuggerNonUserCode]
		get
		{
			return _canvasCuadro5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			DragEventHandler val = new DragEventHandler(Canvas_Drop);
			if (_canvasCuadro5 != null)
			{
				_canvasCuadro5.Drop -= val;
			}
			_canvasCuadro5 = value;
			if (_canvasCuadro5 != null)
			{
				_canvasCuadro5.Drop += val;
			}
		}
	}

	internal virtual Canvas canvasCuadro6
	{
		[DebuggerNonUserCode]
		get
		{
			return _canvasCuadro6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			DragEventHandler val = new DragEventHandler(Canvas_Drop);
			if (_canvasCuadro6 != null)
			{
				_canvasCuadro6.Drop -= val;
			}
			_canvasCuadro6 = value;
			if (_canvasCuadro6 != null)
			{
				_canvasCuadro6.Drop += val;
			}
		}
	}

	internal virtual Border Border1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Border1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Border1 = value;
		}
	}

	internal virtual Border Border2
	{
		[DebuggerNonUserCode]
		get
		{
			return _Border2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Border2 = value;
		}
	}

	internal virtual Border Border3
	{
		[DebuggerNonUserCode]
		get
		{
			return _Border3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Border3 = value;
		}
	}

	internal virtual Border Border4
	{
		[DebuggerNonUserCode]
		get
		{
			return _Border4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Border4 = value;
		}
	}

	internal virtual Border Border5
	{
		[DebuggerNonUserCode]
		get
		{
			return _Border5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Border5 = value;
		}
	}

	internal virtual Border Border6
	{
		[DebuggerNonUserCode]
		get
		{
			return _Border6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Border6 = value;
		}
	}

	internal virtual Button bBorrar
	{
		[DebuggerNonUserCode]
		get
		{
			return _bBorrar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			RoutedEventHandler val = new RoutedEventHandler(bBorrar_Click);
			if (_bBorrar != null)
			{
				_bBorrar.Click -= val;
			}
			_bBorrar = value;
			if (_bBorrar != null)
			{
				_bBorrar.Click += val;
			}
		}
	}

	internal virtual TextBox tbTexto
	{
		[DebuggerNonUserCode]
		get
		{
			return _tbTexto;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_tbTexto = value;
		}
	}

	internal virtual Button bGlobo
	{
		[DebuggerNonUserCode]
		get
		{
			return _bGlobo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			RoutedEventHandler val = new RoutedEventHandler(bGlobo_Click);
			if (_bGlobo != null)
			{
				_bGlobo.Click -= val;
			}
			_bGlobo = value;
			if (_bGlobo != null)
			{
				_bGlobo.Click += val;
			}
		}
	}

	internal virtual Button bImprimir
	{
		[DebuggerNonUserCode]
		get
		{
			return _bImprimir;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			RoutedEventHandler val = new RoutedEventHandler(bImprimir_Click);
			if (_bImprimir != null)
			{
				_bImprimir.Click -= val;
			}
			_bImprimir = value;
			if (_bImprimir != null)
			{
				_bImprimir.Click += val;
			}
		}
	}

	internal virtual ComboBox cbFiguras
	{
		[DebuggerNonUserCode]
		get
		{
			return _cbFiguras;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			SelectionChangedEventHandler val = new SelectionChangedEventHandler(ComboBox1_SelectionChanged);
			if (_cbFiguras != null)
			{
				_cbFiguras.SelectionChanged -= val;
			}
			_cbFiguras = value;
			if (_cbFiguras != null)
			{
				_cbFiguras.SelectionChanged += val;
			}
		}
	}

	internal virtual TextBlock TextBlock1
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBlock1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TextBlock1 = value;
		}
	}

	internal virtual TextBlock TextBlock2
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBlock2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TextBlock2 = value;
		}
	}

	internal virtual Button bNubeDer
	{
		[DebuggerNonUserCode]
		get
		{
			return _bNubeDer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			RoutedEventHandler val = new RoutedEventHandler(bNubeDer_Click);
			if (_bNubeDer != null)
			{
				_bNubeDer.Click -= val;
			}
			_bNubeDer = value;
			if (_bNubeDer != null)
			{
				_bNubeDer.Click += val;
			}
		}
	}

	internal virtual Button bOvaloIzq
	{
		[DebuggerNonUserCode]
		get
		{
			return _bOvaloIzq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			RoutedEventHandler val = new RoutedEventHandler(bOvaloIzq_Click);
			if (_bOvaloIzq != null)
			{
				_bOvaloIzq.Click -= val;
			}
			_bOvaloIzq = value;
			if (_bOvaloIzq != null)
			{
				_bOvaloIzq.Click += val;
			}
		}
	}

	internal virtual Button bOvaloDer
	{
		[DebuggerNonUserCode]
		get
		{
			return _bOvaloDer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			RoutedEventHandler val = new RoutedEventHandler(bOvaloDer_Click);
			if (_bOvaloDer != null)
			{
				_bOvaloDer.Click -= val;
			}
			_bOvaloDer = value;
			if (_bOvaloDer != null)
			{
				_bOvaloDer.Click += val;
			}
		}
	}

	internal virtual Button bCuadroIzq
	{
		[DebuggerNonUserCode]
		get
		{
			return _bCuadroIzq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			RoutedEventHandler val = new RoutedEventHandler(bCuadroIzq_Click);
			if (_bCuadroIzq != null)
			{
				_bCuadroIzq.Click -= val;
			}
			_bCuadroIzq = value;
			if (_bCuadroIzq != null)
			{
				_bCuadroIzq.Click += val;
			}
		}
	}

	internal virtual Button bCuadroDer
	{
		[DebuggerNonUserCode]
		get
		{
			return _bCuadroDer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			RoutedEventHandler val = new RoutedEventHandler(bCuadroDer_Click);
			if (_bCuadroDer != null)
			{
				_bCuadroDer.Click -= val;
			}
			_bCuadroDer = value;
			if (_bCuadroDer != null)
			{
				_bCuadroDer.Click += val;
			}
		}
	}

	internal virtual Button bCuadro
	{
		[DebuggerNonUserCode]
		get
		{
			return _bCuadro;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			RoutedEventHandler val = new RoutedEventHandler(bCuadro_Click);
			if (_bCuadro != null)
			{
				_bCuadro.Click -= val;
			}
			_bCuadro = value;
			if (_bCuadro != null)
			{
				_bCuadro.Click += val;
			}
		}
	}

	internal virtual Button bGuardar
	{
		[DebuggerNonUserCode]
		get
		{
			return _bGuardar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			RoutedEventHandler val = new RoutedEventHandler(bGuardar_Click);
			if (_bGuardar != null)
			{
				_bGuardar.Click -= val;
			}
			_bGuardar = value;
			if (_bGuardar != null)
			{
				_bGuardar.Click += val;
			}
		}
	}

	internal virtual TextBlock TextBlock3
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBlock3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TextBlock3 = value;
		}
	}

	internal virtual Button bAbrir
	{
		[DebuggerNonUserCode]
		get
		{
			return _bAbrir;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			RoutedEventHandler val = new RoutedEventHandler(bAbrir_Click);
			if (_bAbrir != null)
			{
				_bAbrir.Click -= val;
			}
			_bAbrir = value;
			if (_bAbrir != null)
			{
				_bAbrir.Click += val;
			}
		}
	}

	internal virtual Button bNuevo
	{
		[DebuggerNonUserCode]
		get
		{
			return _bNuevo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			RoutedEventHandler val = new RoutedEventHandler(bNuevo_Click);
			if (_bNuevo != null)
			{
				_bNuevo.Click -= val;
			}
			_bNuevo = value;
			if (_bNuevo != null)
			{
				_bNuevo.Click += val;
			}
		}
	}

	public MainPage()
	{
		this.Drop += new DragEventHandler(Canvas_Drop);
		lNubes = new List<cFigura>();
		lGlobos_Imprimir = new List<cFigura>();
		iTotalNubes = -1;
		iHijoActual = 7;
		InitializeComponent();
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
			val.SetSource(array[0].OpenRead());
			Image val2 = new Image();
			position.Y = 0.0;
			position.X = 0.0;
			val2.Width = Conversions.ToDouble(NewLateBinding.LateGet(sender, null, "Width", new object[0], null, null, null));
			val2.Height = Conversions.ToDouble(NewLateBinding.LateGet(sender, null, "Height", new object[0], null, null, null));
			val2.Source = (ImageSource)(object)val;
			val2.SetValue(Canvas.TopProperty, position.Y);
			val2.SetValue(Canvas.LeftProperty, position.X);
			val2.Stretch = (Stretch)1;
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
		Point position = e.GetPosition((UIElement)(object)canvasComic);
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
			Point position = e.GetPosition((UIElement)(object)canvasComic);
			if ((position.Y + lNubes[iNubeActual].newImage.Height < canvasComic.Height) & (position.X + lNubes[iNubeActual].newImage.Width < canvasComic.Width))
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
			((PresentationFrameworkCollection<object>)(object)cbFiguras.Items).Add(sFigura + num);
			cFigura2.SetImagen(tbTexto.Text, dropPoint, iFigura, iNubeActual);
			cFigura2.iHijo = ((PresentationFrameworkCollection<UIElement>)(object)canvasComic.Children).Count + 1;
			lNubes.Add(cFigura2);
			((PresentationFrameworkCollection<UIElement>)(object)canvasComic.Children).Add((UIElement)(object)lNubes[cFigura2.iNumero].newImage);
			((PresentationFrameworkCollection<UIElement>)(object)canvasComic.Children).Add((UIElement)(object)lNubes[cFigura2.iNumero].tb);
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
			((PresentationFrameworkCollection<object>)(object)cbFiguras.Items).Add(sFigura + num);
			cFigura2.SetImagen(tbTexto.Text, dropPoint, iFigura, iNubeActual);
			cFigura2.iHijo = ((PresentationFrameworkCollection<UIElement>)(object)canvasComic.Children).Count + 1;
			lNubes.Add(cFigura2);
			((PresentationFrameworkCollection<UIElement>)(object)canvasComic.Children).Add((UIElement)(object)lNubes[cFigura2.iNumero].newImage);
			((PresentationFrameworkCollection<UIElement>)(object)canvasComic.Children).Add((UIElement)(object)lNubes[cFigura2.iNumero].tb);
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
		((PresentationFrameworkCollection<UIElement>)(object)canvasComic.Children).RemoveAt(lNubes[iNubeActual].iHijo);
		checked
		{
			((PresentationFrameworkCollection<UIElement>)(object)canvasComic.Children).RemoveAt(lNubes[iNubeActual].iHijo - 1);
			lNubes.RemoveAt(iNubeActual);
			((PresentationFrameworkCollection<object>)(object)cbFiguras.Items).RemoveAt(iNubeActual);
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
		Image val = new Image();
		if (((PresentationFrameworkCollection<UIElement>)(object)canvasCuadro1.Children).Count > 0)
		{
			WriteableBitmap bitmap = new WriteableBitmap((UIElement)(object)canvasCuadro1, new TransformGroup());
			_SaveToDisk(_GetSaveBuffer(bitmap), "c:\\prueba.jpg");
		}
		checked
		{
			using IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
			using IsolatedStorageFileStream isolatedStorageFileStream = new IsolatedStorageFileStream("WebComic.xml", FileMode.Create, isf);
			XmlWriterSettings val2 = new XmlWriterSettings();
			val2.Indent = true;
			XmlWriter val3 = XmlWriter.Create(isolatedStorageFileStream, val2);
			try
			{
				val3.WriteComment("Web Comic");
				val3.WriteStartElement("figuras");
				int num = lNubes.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					val3.WriteStartElement("globo");
					cFigura cFigura2 = new cFigura();
					val3.WriteElementString("X", lNubes[num2].Punto.X.ToString());
					val3.WriteElementString("Y", lNubes[num2].Punto.Y.ToString());
					val3.WriteElementString("Tipo", lNubes[num2].iTipo.ToString());
					val3.WriteElementString("Texto", lNubes[num2].tb.Text);
					val3.WriteEndElement();
					num2++;
				}
				val3.WriteEndElement();
				val3.WriteEndDocument();
				val3.Flush();
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
		}
	}

	private void bAbrir_Click(object sender, RoutedEventArgs e)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		cFigura cFigura2 = new cFigura();
		using (IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication())
		{
			string s;
			using (StreamReader streamReader = new StreamReader(isolatedStorageFile.OpenFile("WebComic.xml", FileMode.Open)))
			{
				s = streamReader.ReadToEnd();
			}
			XmlReader val = XmlReader.Create(new StringReader(s));
			try
			{
				XmlWriterSettings val2 = new XmlWriterSettings();
				val2.Indent = true;
				lNubes.Clear();
				iNubeActual = 0;
				iTotalNubes = -1;
				iHijoActual = 7;
				Point val3 = default(Point);
				while (val.Read())
				{
					switch (val.NodeType - 1)
					{
						case 0:
							switch (val.Name)
							{
								case "globo":
									num = checked(num + 1);
									break;
								case "X":
									if (val.Read())
									{
										cFigura2.Punto.X = Conversions.ToInteger(val.Value);
										val3.X = cFigura2.Punto.X;
									}
									break;
								case "Y":
									if (val.Read())
									{
										cFigura2.Punto.Y = Conversions.ToInteger(val.Value);
										val3.Y = cFigura2.Punto.Y;
									}
									break;
								case "Tipo":
									if (val.Read())
									{
										cFigura2.Punto = val3;
										cFigura2.iTipo = Conversions.ToInteger(val.Value);
									}
									break;
								case "Texto":
									if (val.Read())
									{
										cFigura2.tb.Text = val.Value;
										tbTexto.Text = cFigura2.tb.Text;
										GuardaFigura(cFigura2.iTipo, "Figura", val3);
										cFigura2.SetPosicion(val3);
										tbTexto.Text = "";
									}
									break;
							}
							break;
					}
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		TextBlock3.Text = stringBuilder.ToString();
	}

	private void bNuevo_Click(object sender, RoutedEventArgs e)
	{
		checked
		{
			int num = ((PresentationFrameworkCollection<UIElement>)(object)canvasComic.Children).Count - 1;
			while (true)
			{
				int num2 = num;
				int num3 = 12;
				if (num2 < num3)
				{
					break;
				}
				canvasComic.Children.RemoveAt(num);
				num += -1;
			}
			if (canvasCuadro1.Children.Count > 0)
			{
				((PresentationFrameworkCollection<UIElement>)(object)canvasCuadro1.Children).RemoveAt(0);
			}
			if (((PresentationFrameworkCollection<UIElement>)(object)canvasCuadro2.Children).Count > 0)
			{
				((PresentationFrameworkCollection<UIElement>)(object)canvasCuadro2.Children).RemoveAt(0);
			}
			if (((PresentationFrameworkCollection<UIElement>)(object)canvasCuadro3.Children).Count > 0)
			{
				((PresentationFrameworkCollection<UIElement>)(object)canvasCuadro3.Children).RemoveAt(0);
			}
			if (((PresentationFrameworkCollection<UIElement>)(object)canvasCuadro4.Children).Count > 0)
			{
				((PresentationFrameworkCollection<UIElement>)(object)canvasCuadro4.Children).RemoveAt(0);
			}
			if (((PresentationFrameworkCollection<UIElement>)(object)canvasCuadro5.Children).Count > 0)
			{
				((PresentationFrameworkCollection<UIElement>)(object)canvasCuadro5.Children).RemoveAt(0);
			}
			if (((PresentationFrameworkCollection<UIElement>)(object)canvasCuadro6.Children).Count > 0)
			{
				((PresentationFrameworkCollection<UIElement>)(object)canvasCuadro6.Children).RemoveAt(0);
			}
			((PresentationFrameworkCollection<object>)(object)cbFiguras.Items).Clear();
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
			int num2 = 0;
			Point dropPoint = default(Point);
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				cFigura cFigura2 = new cFigura();
				dropPoint.Y = lNubes[num2].Punto.Y;
				dropPoint.X = lNubes[num2].Punto.X;
				cFigura2.SetImagen(lNubes[num2].tb.Text, dropPoint, lNubes[num2].iTipo, num2);
				((PresentationFrameworkCollection<UIElement>)(object)val.Children).Add((UIElement)(object)cFigura2.newImage);
				((PresentationFrameworkCollection<UIElement>)(object)val.Children).Add((UIElement)(object)cFigura2.tb);
				num2++;
			}
			PrintDocument val2 = new PrintDocument();
			val2.BeginPrint += [SpecialName] (object s, BeginPrintEventArgs args) =>
			{
				AnonymousMethod5(RuntimeHelpers.GetObjectValue(s), args);
			};
			val2.PrintPage += [SpecialName] (object s, PrintPageEventArgs args) =>
			{
				AnonymousMethod6(RuntimeHelpers.GetObjectValue(s), args, canvasComic);
			};
			val2.EndPrint += [SpecialName] (object s, EndPrintEventArgs args) =>
			{
				AnonymousMethod7(RuntimeHelpers.GetObjectValue(s), args, canvasComic);
			};
			val2.Print("Printing Comic");
		}
	}

	private static void _SaveToDisk(byte[] buffer, string fileName)
	{
		using IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
		using IsolatedStorageFileStream isolatedStorageFileStream = new IsolatedStorageFileStream(fileName, FileMode.CreateNew, isf);
		isolatedStorageFileStream.Write(buffer, 0, buffer.Length);
	}

	private static byte[] _GetSaveBuffer(WriteableBitmap bitmap)
	{
		checked
		{
			long num = bitmap.PixelWidth * bitmap.PixelHeight;
			long num2 = num * 4 + 4;
			byte[] array = new byte[(int)(num2 - 1) + 1];
			long location = 0L;
			array[(int)Math.Max(Interlocked.Increment(ref location), location - 1)] = (byte)((long)Math.Round(bitmap.PixelWidth / 256.0) & 0xFF);
			array[(int)Math.Max(Interlocked.Increment(ref location), location - 1)] = (byte)(unchecked(bitmap.PixelWidth % 256) & 0xFF);
			array[(int)Math.Max(Interlocked.Increment(ref location), location - 1)] = (byte)((long)Math.Round(bitmap.PixelHeight / 256.0) & 0xFF);
			array[(int)Math.Max(Interlocked.Increment(ref location), location - 1)] = (byte)(unchecked(bitmap.PixelHeight % 256) & 0xFF);
			int num3 = (int)(num - 1);
			int num4 = 0;
			while (true)
			{
				int num5 = num4;
				int num6 = num3;
				if (num5 > num6)
				{
					break;
				}
				array[(int)Math.Max(Interlocked.Increment(ref location), location - 1)] = (byte)((bitmap.Pixels[num4] >> 24) & 0xFF);
				array[(int)Math.Max(Interlocked.Increment(ref location), location - 1)] = (byte)((bitmap.Pixels[num4] >> 16) & 0xFF);
				array[(int)Math.Max(Interlocked.Increment(ref location), location - 1)] = (byte)((bitmap.Pixels[num4] >> 8) & 0xFF);
				array[(int)Math.Max(Interlocked.Increment(ref location), location - 1)] = (byte)(bitmap.Pixels[num4] & 0xFF);
				num4++;
			}
			return array;
		}
	}

	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Application.LoadComponent(this, new Uri("/comic;component/MainPage.xaml", UriKind.Relative));
			canvasComic = (Canvas)this.FindName("canvasComic");
			canvasCuadro1 = (Canvas)this.FindName("canvasCuadro1");
			canvasCuadro4 = (Canvas)this.FindName("canvasCuadro4");
			canvasCuadro2 = (Canvas)this.FindName("canvasCuadro2");
			canvasCuadro3 = (Canvas)this.FindName("canvasCuadro3");
			canvasCuadro5 = (Canvas)this.FindName("canvasCuadro5");
			canvasCuadro6 = (Canvas)this.FindName("canvasCuadro6");
			Border1 = (Border)this.FindName("Border1");
			Border2 = (Border)this.FindName("Border2");
			Border3 = (Border)this.FindName("Border3");
			Border4 = (Border)this.FindName("Border4");
			Border5 = (Border)this.FindName("Border5");
			Border6 = (Border)this.FindName("Border6");
			bBorrar = (Button)this.FindName("bBorrar");
			tbTexto = (TextBox)this.FindName("tbTexto");
			bGlobo = (Button)this.FindName("bGlobo");
			bImprimir = (Button)this.FindName("bImprimir");
			cbFiguras = (ComboBox)this.FindName("cbFiguras");
			TextBlock1 = (TextBlock)this.FindName("TextBlock1");
			TextBlock2 = (TextBlock)this.FindName("TextBlock2");
			bNubeDer = (Button)this.FindName("bNubeDer");
			bOvaloIzq = (Button)this.FindName("bOvaloIzq");
			bOvaloDer = (Button)this.FindName("bOvaloDer");
			bCuadroIzq = (Button)this.FindName("bCuadroIzq");
			bCuadroDer = (Button)this.FindName("bCuadroDer");
			bCuadro = (Button)this.FindName("bCuadro");
			bGuardar = (Button)this.FindName("bGuardar");
			TextBlock3 = (TextBlock)this.FindName("TextBlock3");
			bAbrir = (Button)this.FindName("bAbrir");
			bNuevo = (Button)this.FindName("bNuevo");
		}
	}
}

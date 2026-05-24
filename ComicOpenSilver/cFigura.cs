using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.VisualBasic.CompilerServices;

namespace comic;

public class cFigura
{
    public TextBlock tb;

    public int iTipo;

    public int iNumero;

    public int iHijo;

    public int iAux;

    public Point Punto;

    public Image newImage;

    public cFigura()
    {
        //IL_0008: Unknown result type (might be due to invalid IL or missing references)
        //IL_0012: Expected O, but got Unknown
        //IL_0013: Unknown result type (might be due to invalid IL or missing references)
        //IL_001d: Expected O, but got Unknown
        tb = new TextBlock();
        newImage = new Image();
    }

    public void SetImagen(string sTexto, Point dropPoint, int iFigura, int iActual)
    {
        string uriString = "";
        tb.Text = "  " + sTexto;
        tb.Foreground = (Brush)new SolidColorBrush(Colors.Black);
        tb.TextAlignment = (TextAlignment)0;
        tb.TextWrapping = (TextWrapping)2;
        iTipo = iFigura;
        iNumero = iActual;
        switch (iTipo)
        {
            case 1:
                uriString = "Images/nube_izquierda.png";
                break;
            case 2:
                uriString = "Images/nube_derecha1.png";
                break;
            case 3:
                uriString = "Images/ovalo_derecha1.png";
                break;
            case 4:
                uriString = "Images/ovalo_izquierda1.png";
                break;
            case 5:
                uriString = "Images/rectangulo_derecha1.png";
                break;
            case 6:
                uriString = "Images/rectangulo_izquierdo1.png";
                break;
            case 7:
                uriString = "Images/rectangulo1.png";
                break;
        }
        BitmapImage val = new BitmapImage(new Uri(uriString, UriKind.Relative));
        ((FrameworkElement)newImage).Width = ((FrameworkElement)tb).ActualWidth + 50.0;
        ((FrameworkElement)newImage).Height = ((FrameworkElement)tb).ActualHeight;
        if (iTipo <= 6)
        {
            Image val2 = newImage;
            ((FrameworkElement)val2).Height = ((FrameworkElement)val2).Height + 30.0;
            ((DependencyObject)tb).SetValue(Canvas.TopProperty, (object)(((Point)(dropPoint)).Y + 8.0));
        }
        else
        {
            Image val2 = newImage;
            ((FrameworkElement)val2).Height = ((FrameworkElement)val2).Height + 10.0;
            ((DependencyObject)tb).SetValue(Canvas.TopProperty, (object)(((Point)(dropPoint)).Y + 5.0));
        }
        ((DependencyObject)tb).SetValue(Canvas.LeftProperty, (object)(((Point)(dropPoint)).X + 18.0));
        ((DependencyObject)newImage).SetValue(Canvas.LeftProperty, (object)((Point)(dropPoint)).X);
        ((DependencyObject)newImage).SetValue(Canvas.TopProperty, (object)((Point)(dropPoint)).Y);
        Punto.Y = Conversions.ToDouble(((DependencyObject)tb).GetValue(Canvas.TopProperty));
        Punto.X = Conversions.ToDouble(((DependencyObject)tb).GetValue(Canvas.LeftProperty));
        newImage.Source = (ImageSource)(object)val;
        newImage.Stretch = (Stretch)1;
        ((UIElement)newImage).MouseLeftButtonDown += new MouseButtonEventHandler(Image_Mouse_Button_Down);
        ((UIElement)newImage).MouseMove += new MouseEventHandler(Image_Mouse_Button_Move);
        ((UIElement)newImage).MouseLeftButtonUp += new MouseButtonEventHandler(Image_Mouse_Button_Up);
    }

    public void SetPosicion(Point dropPoint)
    {
        ((DependencyObject)newImage).SetValue(Canvas.TopProperty, (object)((Point)(dropPoint)).Y);
        ((DependencyObject)newImage).SetValue(Canvas.LeftProperty, (object)((Point)(dropPoint)).X);
        if (iTipo <= 6)
        {
            ((DependencyObject)tb).SetValue(Canvas.TopProperty, (object)(((Point)(dropPoint)).Y + 8.0));
        }
        else
        {
            ((DependencyObject)tb).SetValue(Canvas.TopProperty, (object)(((Point)(dropPoint)).Y + 5.0));
        }
        ((DependencyObject)tb).SetValue(Canvas.LeftProperty, (object)(((Point)(dropPoint)).X + 18.0));
        Punto.Y = Conversions.ToDouble(((DependencyObject)tb).GetValue(Canvas.TopProperty));
        Punto.X = Conversions.ToDouble(((DependencyObject)tb).GetValue(Canvas.LeftProperty));
    }

    private void Image_Mouse_Button_Down(object sender, MouseButtonEventArgs e)
    {
        iAux = 1;
        MainPage.iNubeActual = iNumero;
        // Tell the document click listener that this click is on a figure, not a panel.
        OpenSilver.Interop.ExecuteJavaScript("window._comicFigureClick = true;");
    }

    private void Image_Mouse_Button_Move(object sender, MouseEventArgs e)
    {
    }

    private void Image_Mouse_Button_Up(object sender, MouseButtonEventArgs e)
    {
        iAux = 0;
    }
}

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Specialized;
using System.Drawing;
using System.Printing;
using System.Text.RegularExpressions;
using System.Timers;
using Emgu.CV;
using Emgu.CV.Ccm;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Microsoft.VisualBasic;
using System.Windows.Input;
using Timer = System.Timers.Timer;


namespace OpenCVAppTest;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
///
public partial class MainWindow : Window
{
    private readonly Timer _timer;
    
    VideoCapture cap = new VideoCapture(1);
    public MainWindow()
    {
        InitializeComponent();
        // _timer = new Timer(100); //Updates every quarter second.
        // _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        // _timer.Enabled = true;
    }
    // private void OnTimedEvent(object source, ElapsedEventArgs e)
    // {
    //     CVProcess();
    //     LHueNumber.Text = "AAAA";
    // }

    private void Slider_Click(object sender, RoutedEventArgs e)
    {
        
        double H = LHueSlider.Value;
        double S = LShaSlider.Value;
        double V = LValSlider.Value;
        ColorRange.lower = new ScalarArray(new MCvScalar(H, S, V));
        
        double Hu = UHueSlider.Value;
        double Su = UShaSlider.Value;
        double Vu = UValSlider.Value;
        ColorRange.upper = new ScalarArray(new MCvScalar(Hu, Su, Vu));
        
        LHueNumber.Text = H.ToString();
        LShaNumber.Text = S.ToString();
        LValNumber.Text = V.ToString();
        
        UHueNumber.Text = Hu.ToString();
        UShaNumber.Text = Su.ToString();
        UValNumber.Text = Vu.ToString();
        
        CVProcess();
    }

    private void CVProcess()
    {
        using (Mat frame = new Mat())
        {
            cap.Read(frame);
    
            Mat mask = new Mat();
            Mat output = new Mat();
            Mat frame2 = new Mat();

    
            CvInvoke.CvtColor(frame, frame2, ColorConversion.Rgb2Hsv);
            CvInvoke.InRange(frame2, ColorRange.lower, ColorRange.upper, mask);
    
            CvInvoke.BitwiseAnd(frame, frame, output, mask);
            Picture.Source = output.ToBitmapSource();

        }
            
    }
}


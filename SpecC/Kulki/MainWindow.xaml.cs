using System.ComponentModel;
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

namespace Kulki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ball ball;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double x = Canvas.GetLeft(BallEllipse);
            double y = Canvas.GetTop(BallEllipse);
            //x += 10;
            //y += 10;
            //Canvas.SetLeft(Ball,x);
            //Canvas.SetTop(Ball, y);
            ball = new Ball(x, y, BallEllipse);
            ball.Start();

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            ball.Stop();
            base.OnClosing(e);
        }
    }
}
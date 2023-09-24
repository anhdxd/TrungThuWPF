using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace TrungThuWPF.Pages
{
    /// <summary>
    /// Interaction logic for ActionPage.xaml
    /// </summary>
    public partial class ActionPage : Page
    {
        public ObservableCollection<string> CarouselImages { get; set; }
        public ActionPage()
        {
            InitializeComponent();

            //DataContext = this;
            //CarouselImages = new ObservableCollection<string>()
            //{
            //"..\\images\\trong1.png",
            //"..\\images\\lan1.png",
            //"..\\images\\trong2.png",
            //"..\\images\\lan2.png",
            //"..\\images\\doan.png",
            //"..\\images\\deadline-icon.png",
            //};
            //media.Play();

            // get media link from folder media
            // get curent folder path

        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            string currentPath = System.IO.Directory.GetCurrentDirectory();
            string videoPath = currentPath + "/media/tt.mp4";
            media.Source = new Uri(videoPath, UriKind.RelativeOrAbsolute);
            media.Play();
            Visibility = Visibility.Hidden;
        }

        public void SlideLeftToRight(double from, double to)
        {
            TranslateTransform translateTransform = new TranslateTransform();
            itemControlImage.RenderTransform = translateTransform;

            DoubleAnimation animation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(10),
                RepeatBehavior = RepeatBehavior.Forever,
                DecelerationRatio = 0.8f
            };

            translateTransform.BeginAnimation(TranslateTransform.XProperty, animation);
        }

        public void StartAnimation()
        {
            //int numOfItem = itemControlImage.Items.Count;
            //double x = -400 * numOfItem;
            //SlideLeftToRight(x, 1280);

            //create task async
            StartMovingImage();
           
        }

        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            // Phương thức Load đã hoàn tất, hiển thị trang
            // Ví dụ: Đặt Visibility của trang thành Visible
            Visibility = Visibility.Visible;
        }
        private void StartMovingImage()
        {

            MovingClass mv_lan1 = new MovingClass(lan1,xMove:-1, yMove:2, speedMove:25, bSplash: true);
            MovingClass mv_lan2 = new MovingClass(lan2, xMove: -2, yMove: 1, speedMove: 10);
            MovingClass mv_trong1 = new MovingClass(trong1, xMove: 1, yMove: 1.1, speedMove: 15, bSplash: true);
            MovingClass mv_trong2 = new MovingClass(trong2, xMove: -1, yMove: 1, speedMove: 12, bSplash:true );
            MovingClass mv_doan = new MovingClass(doan, xMove: 1.5, yMove: 1, speedMove: 6);
            MovingClass mv_deadline = new MovingClass(dl, xMove: -1.5, yMove: 1, speedMove: 8);
            MovingClass mv_denongsao = new MovingClass(denongsao, xMove: 1, yMove: 1, speedMove: 8, bSplash:true);
        }

    }

    public class MovingClass : ActionPage
    {
        private double xDirection = 1; // Hướng di chuyển theo trục x (1: phải, -1: trái)
        private double yDirection = 3; // Hướng di chuyển theo trục y (1: xuống, -1: lên)
        private double speed = 10; // Tốc độ di chuyển của hình ảnh

        private DispatcherTimer timer;
        private Window currentWindow = Application.Current.MainWindow;
        private Image controlImage;
        public MovingClass(object imageMove,double xMove = 1, double yMove = 1, double milisecondSleep = 10, double speedMove = 5, bool bSplash = false) 
        {
            xDirection = xMove;
            yDirection = yMove;
            speed = speedMove;
            controlImage = (Image)imageMove;
            StartMovingImage(milisecondSleep);

            if (bSplash)
            {
                SplashControl();
            }
        }

        private void SplashControl()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(30); // Khung thời gian cố định (20ms)
            timer.Tick += (sender, e) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                if(controlImage.Visibility == Visibility.Hidden)
                    controlImage.Visibility = Visibility.Visible;
                else
                    controlImage.Visibility = Visibility.Hidden;
                });
            };
            timer.Start();
        }
        private void StartMovingImage(double sleepTime)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(sleepTime); // Khung thời gian cố định (20ms)
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                ChangePos(controlImage);
            });

        }

        private void ChangePos(object control)
        {
            //changePos(controlImage);
            var ctl = control as Image;


            // Lấy vị trí hiện tại của hình ảnh
            double currentX = Canvas.GetLeft(ctl);
            double currentY = Canvas.GetTop(ctl);

            // Tính toán vị trí mới của hình ảnh dựa trên hướng di chuyển và tốc độ
            double newX = currentX + (speed * xDirection); // Tốc độ di chuyển theo trục x
            double newY = currentY + (speed * yDirection); // Tốc độ di chuyển theo trục y
            // Get current window

            // Kiểm tra các biên giới của cửa sổ
            if (newX <= 0 || newX + ctl.ActualWidth >= currentWindow.ActualWidth)
            {
                xDirection *= -1; // Đổi hướng di chuyển theo trục x
            }

            if (newY <= 0 || newY + ctl.ActualHeight >= currentWindow.ActualHeight)
            {
                yDirection *= -1; // Đổi hướng di chuyển theo trục y
            }

            // Cập nhật vị trí mới của hình ảnh
            Canvas.SetLeft(ctl, newX);
            Canvas.SetTop(ctl, newY);

        }

    }


}


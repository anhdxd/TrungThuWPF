using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrungThuWPF.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void btnHaveLove_MouseMove(object sender, MouseEventArgs e)
        {
            //change button to random position and no change size button
            Random rd = new Random();
            int x = rd.Next(0, (int)canvas.ActualWidth - (int)btnHaveLove.ActualWidth);
            int y = rd.Next(0, (int)canvas.ActualHeight - (int)btnHaveLove.ActualHeight);

            Canvas.SetLeft(btnHaveLove, x);
            Canvas.SetTop(btnHaveLove, y);

        }

        private void btnnoloveoke_MouseMove(object sender, MouseEventArgs e)
        {
            //change button to random position and no change size button
            Random rd = new Random();
            int x = rd.Next(0, (int)canvas.ActualWidth - (int)btnnoloveoke.ActualWidth);
            int y = rd.Next(0, (int)canvas.ActualHeight - (int)btnnoloveoke.ActualHeight);

            Canvas.SetLeft(btnnoloveoke, x);
            Canvas.SetTop(btnnoloveoke, y);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nolove.Visibility = Visibility.Visible;

            //lambda task
            Task.Run(() =>
            {
                //sleep 3s
                System.Threading.Thread.Sleep(3000);
                //change page to action page
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // Get parent window MainWindow
                    MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                    mainWindow.ChangeNumberPage();
                });
            });


        }
    }
}

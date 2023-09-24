using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for NumberLoadPage.xaml
    /// </summary>
    public partial class NumberLoadPage : Page
    {
        public NumberLoadPage()
        {
            InitializeComponent();

            
        }
        public void LoadNumberTask()
        {
            Task.Run(() => LoadNumber());
        }
        void LoadNumber()
        {
            int timeSleep = 700;
            Application.Current.Dispatcher.Invoke(() =>
            {
                textBlock.Text = "3";
            });
            Thread.Sleep(timeSleep);
            Application.Current.Dispatcher.Invoke(() =>
            {
                textBlock.Text = "2";
            });
            Thread.Sleep(timeSleep);

            Application.Current.Dispatcher.Invoke(() =>
            {
                textBlock.Text = "1";
            });
            Thread.Sleep(timeSleep);
            Application.Current.Dispatcher.Invoke(() =>
            {
                textBlock.Text = "0";
            });
            Thread.Sleep(timeSleep);
            Application.Current.Dispatcher.Invoke(() =>
            {
                // Get parent window MainWindow
                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                mainWindow.ChangeActionPage();
            });
        }
    }
}

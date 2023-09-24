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
using TrungThuWPF.Pages;
namespace TrungThuWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ActionPage actionPage = new ActionPage();
        private readonly MainPage mainPage = new MainPage();
        private readonly NumberLoadPage numberLoadPage = new NumberLoadPage();
        public MainWindow()
        {
            InitializeComponent();
            frame.Content = mainPage;
        }
        
        public void ChangeNumberPage()
        {
              //change page to number page
            frame.Content = numberLoadPage;
            numberLoadPage.LoadNumberTask();
        }

        public void ChangeActionPage()
        {
            //change page to action page
            frame.Content = actionPage;
            actionPage.StartAnimation();


        }
    }
}

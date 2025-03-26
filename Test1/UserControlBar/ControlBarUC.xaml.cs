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

namespace Test1.UserControlBar
{
    /// <summary>
    /// Interaction logic for ControlBarUC.xaml
    /// </summary>
    public partial class ControlBarUC : UserControl
    {
        public ControlBarUC()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if (window != null)
            {
                window.Close();
            }
        }

        private void btnZoomIn_Click(object sender, RoutedEventArgs e)
        {
           Window windown = Window.GetWindow(this);
           if(windown != null)
            {
                if(windown.WindowState == WindowState.Maximized)
                {
                    windown.WindowState = WindowState.Normal;
                }
                else
                {
                    windown.WindowState = WindowState.Maximized;
                }
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Window windown = Window.GetWindow(this);
            if(windown != null) {
                windown.WindowState = WindowState.Minimized;
            }

        }
    }
}

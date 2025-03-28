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
using System.Windows.Shapes;

namespace Test1.View
{
    /// <summary>
    /// Interaction logic for CreaditCard.xaml
    /// </summary>
    public partial class CreaditCard : Window
    {
        public CreaditCard()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSaveCreadit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank you for createdit","Successful",MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

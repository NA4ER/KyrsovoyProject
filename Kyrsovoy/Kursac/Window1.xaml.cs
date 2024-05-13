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

namespace Kursac
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            MainFraime.Navigate(new ClientData());
            Manager.MainFraime = MainFraime;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFraime.Navigate(new ClientData());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainFraime.Navigate(new CarData());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainFraime.Navigate(new Sales());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainFraime.Navigate(new Orders());
        }
    }
}

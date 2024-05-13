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

namespace Kursac
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLog_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "Admin" && Password.Password == "admin")
            {
                Window1 AdminWindow = new Window1();
                AdminWindow.Show();
            }

            else if (Login.Text == "User" && Password.Password == "user")
            {
                Window2 UserWindow = new Window2();
                UserWindow.Show();
            }

            else
            {
                MessageBox.Show("Пароль или логин введен не верно!");
            }

            
        }
    }
}

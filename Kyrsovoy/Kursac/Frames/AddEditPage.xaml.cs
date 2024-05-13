using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        readonly DB dbc = new DB();
        

        public AddEditPage(Client DB)
        {
            InitializeComponent();

          

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LastName.Text) || string.IsNullOrEmpty(Name.Text) || string.IsNullOrEmpty(MiddleName.Text)
                || string.IsNullOrEmpty(Phone.Text))
            {
                MessageBox.Show("Заполните все поля!", "Уведомление");
                return;
            }

            var query = $" insert into Client (LastName, Name, MiddleName, Phone) values( N'{LastName.Text}', N'{Name.Text}', N'{MiddleName.Text}', N'{Phone.Text}')";
            if (dbc.Execute(query) != null)
            {
                MessageBox.Show("Успешно!", "Уведомление");
                DB.sqlConnection.Close();
            }
            DB.sqlConnection.Close(); 
        }
    }
}

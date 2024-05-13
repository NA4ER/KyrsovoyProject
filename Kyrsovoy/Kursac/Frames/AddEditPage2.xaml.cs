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
    /// Логика взаимодействия для AddEditPage2.xaml
    /// </summary>
    public partial class AddEditPage2 : Page
    {

       readonly DB dbc = new DB();

        public AddEditPage2(Car DB)
        {
            InitializeComponent();


        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(Brand.Text) || string.IsNullOrEmpty(Model.Text) || string.IsNullOrEmpty(Year.Text)
                || string.IsNullOrEmpty(Price.Text))
            {
                MessageBox.Show("Заполните все поля!", "Уведомление");
                return;
            }

            var query = $" insert into Car ( Brand, Model, Year, Price, Description) values(N'{Brand.Text}', N'{Model.Text}',N'{Year.Text}',  N'{Price.Text}', N'{Description.Text}')";
            if (dbc.Execute(query) != null)
            {
                MessageBox.Show("Успешно!", "Уведомление");
                DB.sqlConnection.Close();
            }
            DB.sqlConnection.Close();




        }
    }
}

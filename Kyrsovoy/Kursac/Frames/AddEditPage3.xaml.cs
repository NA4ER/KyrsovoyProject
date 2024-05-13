using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
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
    /// Логика взаимодействия для AddEditPage3.xaml
    /// </summary>
    public partial class AddEditPage3 : System.Windows.Controls.Page
    {

        readonly DB dbc = new DB();

        public AddEditPage3()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CarID.Text) || string.IsNullOrEmpty(ClientID.Text) || string.IsNullOrEmpty(EmployeeID.Text)
                || string.IsNullOrEmpty(DateOfSale.Text) || string.IsNullOrEmpty(SalesAmount.Text))
            {
                MessageBox.Show("Заполните все поля!", "Уведомление");
                return;
            }

            var query = $" insert into Sales ( CarID , CLientID, EmployeeID , DateOfSale, SalesAmount) values(N'{CarID.Text}', N'{ClientID.Text}',N'{EmployeeID.Text}',  N'{DateOfSale.Text}', N'{SalesAmount.Text}')";
            if (dbc.Execute(query) != null)
            {
                MessageBox.Show("Успешно!", "Уведомление");
                DB.sqlConnection.Close();
            }
            DB.sqlConnection.Close();
        }
    }
}

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
    /// Логика взаимодействия для AddEditPage4.xaml
    /// </summary>
    public partial class AddEditPage4 : System.Windows.Controls.Page
    {
        readonly DB dbc = new DB();

        public AddEditPage4()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ClientID.Text) || string.IsNullOrEmpty(CarID.Text) || string.IsNullOrEmpty(Date.Text))
                
            {
                MessageBox.Show("Заполните все поля!", "Уведомление");
                return;
            }

            var query = $" insert into Orders (ClientID, CarID, Date) values(N'{ClientID.Text}', N'{CarID.Text}',N'{Date.Text}')";
            if (dbc.Execute(query) != null)
            {
                MessageBox.Show("Успешно!", "Уведомление");
                DB.sqlConnection.Close();
            }
            DB.sqlConnection.Close();
        }
    }
}

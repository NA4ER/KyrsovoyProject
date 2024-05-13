using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Kursac
{
    internal class DB
    {
        public static string stringCon = @"Data Source=IGROVOI-KOMPYKT\SQLEXPRESS;Initial Catalog=CarShop;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(stringCon);
        public SqlDataAdapter Execute(string query)
        {
            try
            {

                sqlConnection.Open();
                if (sqlConnection.State != ConnectionState.Open)
                {
                    MessageBox.Show("Не удалось установить подключение к базе данных.", "Ошибка");
                    return null;
                }
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
                sda.SelectCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return sda;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Уведомление");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка");
                return null;
            }
        }
        public DataTable ReturnData(string query, DataGrid grid)
        {
            try
            {
                using (SqlConnection myCon = new SqlConnection(stringCon))
                {
                    myCon.Open();
                    if (myCon.State != ConnectionState.Open)
                    {
                        MessageBox.Show("Не удалось установить подключение к базе данных.", "Ошибка");
                        return null;
                    }

                    using (SqlDataAdapter sda = new SqlDataAdapter(query, myCon))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        grid.ItemsSource = dt.AsDataView(); // Обновленная строка
                        return dt;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Возникла ошибка при выполнении запроса: {ex.Message}", "Ошибка");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка");
                return null;
            }
        }
    }
}
    
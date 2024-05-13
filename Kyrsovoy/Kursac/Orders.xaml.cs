using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
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
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace Kursac
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : System.Windows.Controls.Page
    {


        public Orders()
        {
            InitializeComponent();

            DGridOrders.ItemsSource = CarShopEntities.GetContext().Orders.ToList();
        }

        private void WordExport_Click(object sender, RoutedEventArgs e)
        {
            Word.Application word = new Word.Application();
            word.Visible = false; // Установка свойства Visible в false
            Word.Document document = word.Documents.Add();

            Word.Paragraph para = document.Content.Paragraphs.Add();
            para.Range.Text = "Отчет";

            Word.Table table = document.Tables.Add(para.Range, DGridOrders.Items.Count + 1, DGridOrders.Columns.Count);
            table.Borders.Enable = 1;

            for (int j = 0; j < DGridOrders.Columns.Count; j++)
            {
                if (DGridOrders.Columns[j].Header != null)
                {
                    table.Cell(1, j + 1).Range.Text = DGridOrders.Columns[j].Header.ToString();
                }
            }

            for (int i = 0; i < DGridOrders.Items.Count; i++)
            {
                for (int j = 0; j < DGridOrders.Columns.Count; j++)
                {
                    TextBlock b = DGridOrders.Columns[j].GetCellContent(DGridOrders.Items[i]) as TextBlock;
                    if (b != null)
                    {
                        table.Cell(i + 2, j + 1).Range.Text = b.Text;
                    }
                }
            }

            // Запрос у пользователя пути и названия файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                document.SaveAs2(filePath); // Сохранение файла по указанному пути
                document.Close(); // Закрытие документа
                word.Quit(); // Закрытие приложения Word
            }
        }

        private void ExcelExport_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = false;
            Workbook workbook = excel.Workbooks.Add();
            Worksheet worksheet = workbook.ActiveSheet;
            if (DGridOrders != null)
            {
                for (int j = 0; j < DGridOrders.Columns.Count; j++)
                {
                    if (DGridOrders.Columns[j].Header != null)
                    {
                        worksheet.Cells[2, j + 1] = DGridOrders.Columns[j].Header.ToString();
                    }
                }

                for (int i = 0; i < DGridOrders.Items.Count; i++)
                {
                    for (int j = 0; j < DGridOrders.Columns.Count; j++)
                    {
                        TextBlock b = DGridOrders.Columns[j].GetCellContent(DGridOrders.Items[i]) as TextBlock;
                        if (b != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = b.Text;
                        }
                    }
                }
            }

            else
            {
                MessageBox.Show("datagridcar не инициализирован или равен null.");
                worksheet.Cells[1, 1] = "Отчет";
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.* ";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                workbook.SaveAs(filePath);
                workbook.Close();
                excel.Quit();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var OrderForRemoving = DGridOrders.SelectedItems.Cast<Client>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {OrderForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    CarShopEntities.GetContext().Client.RemoveRange(OrderForRemoving);
                    CarShopEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridOrders.ItemsSource = CarShopEntities.GetContext().Client.ToList();

                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFraime.Navigate(new AddEditPage4());
        }
    }
}

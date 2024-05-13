using Microsoft.Office.Interop.Excel;
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

namespace Kursac
{
    /// <summary>
    /// Логика взаимодействия для ClientData.xaml
    /// </summary>
    public partial class ClientData : System.Windows.Controls.Page
    {
     readonly DB dbc = new DB();

     

        public ClientData()
        {
            InitializeComponent();
            
            DGridClient.ItemsSource = CarShopEntities.GetContext().Client.ToList();


        }

       

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFraime.Navigate(new AddEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var ClientForRemoving = DGridClient.SelectedItems.Cast<Client>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ClientForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    CarShopEntities.GetContext().Client.RemoveRange(ClientForRemoving);
                    CarShopEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridClient.ItemsSource = CarShopEntities.GetContext().Client.ToList();

                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void WordExport_Click(object sender, RoutedEventArgs e)
        {
            Word.Application word = new Word.Application();
            word.Visible = false; // Установка свойства Visible в false
            Word.Document document = word.Documents.Add();

            Word.Paragraph para = document.Content.Paragraphs.Add();
            para.Range.Text = "Отчет";

            Word.Table table = document.Tables.Add(para.Range, DGridClient.Items.Count + 1, DGridClient.Columns.Count);
            table.Borders.Enable = 1;

            for (int j = 0; j < DGridClient.Columns.Count; j++)
            {
                if (DGridClient.Columns[j].Header != null)
                {
                    table.Cell(1, j + 1).Range.Text = DGridClient.Columns[j].Header.ToString();
                }
            }

            for (int i = 0; i < DGridClient.Items.Count; i++)
            {
                for (int j = 0; j < DGridClient.Columns.Count; j++)
                {
                    TextBlock b = DGridClient   .Columns[j].GetCellContent(DGridClient.Items[i]) as TextBlock;
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
            

        }
    }
}

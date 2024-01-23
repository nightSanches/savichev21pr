using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using savichev21pr.Classes;
using savichev21pr.Models;

namespace savichev21pr.Pages
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Document Document;
        public string s_src = "";
        public Add(Document Document = null)
        {
            InitializeComponent();
            if (Document != null)
            {
                this.Document = Document;
                if (File.Exists(Document.src))
                {
                    s_src = Document.src;
                    src.Source = new BitmapImage(new Uri(s_src));
                }
                tb_name.Text = this.Document.name;
                tb_user.Text = this.Document.user;
                tb_id.Text = this.Document.id_document;
                tb_date.Text = this.Document.date.ToString("dd.MM.yyyy");
                tb_status.SelectedIndex = this.Document.status;
                tb_vector.Text = this.Document.vector;
                bthAdd.Content = "Изменить";
            }
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }

        private void SelectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "PNG (*.png)|*.png|All file (*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.ShowDialog();
            if(ofd.FileName != "")
            {
                src.Source = new BitmapImage(new Uri(ofd.FileName));
                s_src = ofd.FileName;
            }
        }

        private void AddDocument(object sender, RoutedEventArgs e)
        {
            if (s_src.Length == 0)
            {
                MessageBox.Show("Выберите изображение");
                return;
            }
            if (tb_name.Text.Length == 0)
            {
                MessageBox.Show("Укажите наименование");
                return;
            }
            if (tb_user.Text.Length == 0)
            {
                MessageBox.Show("Укажите ответственного");
                return;
            }
            if (tb_id.Text.Length == 0)
            {
                MessageBox.Show("Укажите код документа");
                return;
            }
            if (tb_date.Text.Length == 0)
            {
                MessageBox.Show("Укажите дату поступления");
                return;
            }
            if (tb_status.Text.Length == 0)
            {
                MessageBox.Show("Укажите статус");
                return;
            }
            if (tb_vector.Text.Length == 0)
            {
                MessageBox.Show("Укажите направление");
                return;
            }
            if (Document == null) // если входящий документ отсутству
            {
                DocumentContext newDocument = new DocumentContext();
                newDocument.src = s_src;
                newDocument.name = tb_name.Text;
                newDocument.user = tb_user.Text;
                newDocument.id_document = tb_id.Text;
                DateTime newDate = new DateTime();
                DateTime.TryParse(tb_date.Text, out newDate);
                newDocument.date = newDate;
                newDocument.status = tb_status.SelectedIndex;
                newDocument.vector = tb_vector.Text;
                newDocument.Save();
                MessageBox.Show("Документ добавлен.");
            }
            else
            {
                DocumentContext newDocument = new DocumentContext();
                newDocument.src = s_src;
                newDocument.id = Document.id;
                newDocument.name = tb_name.Text;
                newDocument.user = tb_user.Text;
                newDocument.id_document = tb_id.Text;
                DateTime newDate = new DateTime();
                DateTime.TryParse(tb_date.Text, out newDate);
                newDocument.date = newDate;
                newDocument.status = tb_status.SelectedIndex;
                newDocument.vector = tb_vector.Text;
                newDocument.Save(true);
                MessageBox.Show("Документ изменён.");
            }
            MainWindow.init.AllDocuments = new DocumentContext().AllDocuments();
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }
    }
}

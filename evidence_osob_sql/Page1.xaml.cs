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

namespace evidence_osob_sql
{
    /// <summary>
    /// Interakční logika pro Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
        public Page1(TodoItem todoItem)
        {
            InitializeComponent();
            Name.Text = todoItem.Name;
            SurName.Text = todoItem.SurName;
            RodneCislo.Content = todoItem.RodneCislo;
            BirthDate.Content = todoItem.BirthDate;
            Gender.Content = todoItem.Gender;
            Added.Content = todoItem.Added;
            Edited.Content = todoItem.Edited;
            Age.Content = todoItem.Age;
            //Number.Text = todoItem.GetNumber.ToString();
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            object obj = item.Content;

            await Database.DeleteItemAsync(obj as TodoItem);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

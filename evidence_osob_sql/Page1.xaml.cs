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
        public object obj;
        public int ID;
        public DateTime birthdate;
        public Page1()
        {
            InitializeComponent();
        }
        public Page1(TodoItem todoItem)
        {
            InitializeComponent();
            obj = todoItem;
            ID = todoItem.ID;
            Name.Text = todoItem.Name;
            SurName.Text = todoItem.SurName;
            RodneCislo.Content = todoItem.RodneCislo;
            BirthDate.Content = todoItem.BirthDate;
            birthdate = todoItem.BirthDate;
            Gender.Content = todoItem.Gender;
            Added.Content = todoItem.Added;
            Edited.Content = todoItem.Edited;
            Age.Content = todoItem.Age;
            //Number.Text = todoItem.GetNumber.ToString();
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //ListViewItem item = sender as ListViewItem;
            //object obj = item.Content;
            MessageBoxResult result = MessageBox.Show("Smazat záznam?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    await Database.DeleteItemAsync(obj as TodoItem);
                    MainPage Page1 = new MainPage();
                    this.NavigationService.Navigate(new MainPage());
                    break;
                case MessageBoxResult.No:
                    break;
            }
            
        }

        private static TodoItemDatabase _database;
        public static TodoItemDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    var fileHelper = new FileHelper();
                    _database = new TodoItemDatabase(fileHelper.GetLocalFilePath("Evidence_osob.db3"));
                }
                return _database;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("", "My App", MessageBoxButton.OK, MessageBoxImage.Information);
            TodoItem item = new TodoItem();
            item.ID = ID;
            item.Name = Name.Text;
            item.SurName = SurName.Text;
            item.RodneCislo = RodneCislo.Content.ToString();
            //item.BirthDate = new DateTime(birthdate.);
            item.Gender = Gender.Content.ToString();
            //item.Edited = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            //item.Added = ;
            Database.SaveItemAsync(item);

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage Page1 = new MainPage();
            this.NavigationService.Navigate(new MainPage());
        }
    }
}

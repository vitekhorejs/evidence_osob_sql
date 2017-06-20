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
        public Page1()
        {
            InitializeComponent();
        }
        public Page1(TodoItem todoItem)
        {
            InitializeComponent();
            //obj = todoItem;
            ID = todoItem.Id;
            obj = todoItem;
            ID = todoItem.Id;
            Name.Text = todoItem.Name;
            Cost.Text = todoItem.Cost;

            var vysledky = Database.GetCatItemsAsyncbyItemID(ID).Result;

            List<Category> kategorie = new List<Category>();

            foreach(CategoryItem catitem in vysledky)
            {
                var vysledkyy = Database.GetCategoryByIdAsync(catitem.ID_Category).Result;
                //kategorie = vysledkyy;
                kategorie.Add(vysledkyy);
            }



            listbox.ItemsSource = kategorie;
        }



        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //ListViewItem item = sender as ListViewItem;
            //object obj = item.Content;
            MessageBoxResult result = MessageBox.Show("Smazat záznam?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    var vysledky = Database.GetCatItemsAsyncbyItemID(ID).Result;
                    await Database.DeleteItemAsync(obj as TodoItem);
                    
                    //await Database.DeleteItemAsync(ID);
                    //await Database.GetCatItemsAsyncbyItemID(ID).Result;
                    foreach (CategoryItem catitem in vysledky)
                    {
                        await Database.DeleteItemAsync(catitem);
                    }
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
                    _database = new TodoItemDatabase(fileHelper.GetLocalFilePath("SQL_test.db3"));
                }
                return _database;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            TodoItem item = new TodoItem();
            item.Id = ID;
            item.Name = Name.Text;
            item.Cost = Cost.Text;
            Database.SaveItemAsync(item);
            MessageBox.Show("Záznam byl aktualizován", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage Page1 = new MainPage();
            this.NavigationService.Navigate(new MainPage());
        }
    }
}

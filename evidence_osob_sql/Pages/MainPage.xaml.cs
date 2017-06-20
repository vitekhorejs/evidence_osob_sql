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
    /// Interakční logika pro MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            //var itemsFromDb = Database.GetItemsAsync().Result;

            //listwiew.ItemsSource = itemsFromDb;
            ItemsToListbox();
            InitDb();
            DisplayResults();
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

        public void ItemsToListbox()
        {
            var vysledky = Database.GetCategoriesAsync().Result;
            listbox.ItemsSource = vysledky;
        }

        public void InitDb()
        {
            var itemsFromDb = Database.GetCategoriesAsync().Result;
            if (itemsFromDb.Count() == 0)
            {
                Category category = new Category();
                category.Name = "Pečivo";
                Database.SaveItemAsync(category);

                Category category1 = new Category();
                category1.Name = "Nápoje";
                Database.SaveItemAsync(category1);

                Category category2 = new Category();
                category2.Name = "Trvanlivé";
                Database.SaveItemAsync(category2);

                Category category3 = new Category();
                category3.Name = "Potraviny";
                Database.SaveItemAsync(category3);

                Category category4 = new Category();
                category4.Name = "Mléčné pordukty";
                Database.SaveItemAsync(category4);

                /*Category category5 = new Category();
                category5.Name = "Skříň";
                Database.SaveItemAsync(category5);

                Category category6 = new Category();
                category6.Name = "PSU";
                Database.SaveItemAsync(category6);

                Category category7 = new Category();
                category7.Name = "GPU";
                Database.SaveItemAsync(category7);

                Category category8 = new Category();
                category8.Name = "Zákl. deska";
                Database.SaveItemAsync(category8);*/
            }
        }

        private void DisplayResults()
        {
            var itemsFromDb = Database.GetItemsAsync().Result;

            listwiew.ItemsSource = itemsFromDb;
        }
        int x = 0;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Name.Text == null)
            {
                MessageBox.Show("Zadejte název", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Name.Text.Any(c => char.IsDigit(c)) == true)
            {
                MessageBox.Show("Neplatné název.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (listbox.SelectedItem == null)
            {
                MessageBox.Show("Vyberte kategorii.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Int32.TryParse(Cost.Text, out x) == false)
            {
                MessageBox.Show("Neplatná cena.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                TodoItem item = new TodoItem();
                item.Name = Name.Text;
                item.Cost = Cost.Text;
                Database.SaveItemAsync(item);

                var vysedek = Database.GetIdbyName(item.Name).Result;


                
                foreach(Category kategorie in listbox.SelectedItems)
                {
                    //Category cat = listbox.SelectedItems as Category;
                    CategoryItem catitem = new CategoryItem();
                    catitem.ID_Category = kategorie.Id;
                    catitem.ID_TodoItem = vysedek.Id;
                    Database.SaveItemAsync(catitem);
                }

          

                //catitem.ID_Category = catitem.ID_Category;

                DisplayResults();
                

            }
        }

        public void listViewItem_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            object obj = item.Content;
            Page1 Page1 = new Page1();
            this.NavigationService.Navigate(new Page1(obj as TodoItem));
        }

        /*private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayResults();
        }*/

        /*
         
        public void listViewItem_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            object obj = item.Content;
            Page1 Page1 = new Page1();
            this.NavigationService.Navigate(new Page1(obj as TodoItem));
        }

        */
    }
}

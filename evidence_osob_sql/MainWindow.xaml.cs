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
using SQLite;

namespace evidence_osob_sql
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TodoItem item = new TodoItem();
            item.Name = "Vítek";
            item.SurName = "Horejš";
            item.RodneCislo = "56104651/5641";
            item.Gender = "Apache";
            item.BirthDate = new DateTime(1990,2,10);
            item.Added = new DateTime().ToString();
            Database.SaveItemAsync(item);

            var itemsFromDb = Database.GetItemsAsync().Result;

            tabulka.ItemsSource = itemsFromDb;
        }
        private static TodoItemDatabase _database;
        public static TodoItemDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    var fileHelper = new FileHelper();
                    _database = new TodoItemDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database;
            }
        }
    }
}

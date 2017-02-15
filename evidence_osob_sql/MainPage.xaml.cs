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

            /*TodoItem item = new TodoItem();
           item.Name = "Vítek";
           item.SurName = "Horejš";
           item.RodneCislo = "56104651/5641";
           item.Gender = "Apache";
           item.BirthDate = new DateTime(1990, 2, 10);
           item.Added = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
           item.Edited = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
           //http://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-in-c
           // upravit automatickou korekci zadavání u rodného čísla - lomítko
           Database.SaveItemAsync(item);*/

            var itemsFromDb = Database.GetItemsAsync().Result;

            listwiew.ItemsSource = itemsFromDb;
        }
        protected void ListView_MouseOneClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Hello, world!", "My App", MessageBoxButton.OK, MessageBoxImage.Information);
            Page1 Page1 = new Page1();
            this.NavigationService.Navigate(Page1);
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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var itemsFromDb = Database.GetItemsAsync().Result;

            listwiew.ItemsSource = itemsFromDb;
        }
        int x = 0;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Name.Text == null)
            {
                MessageBox.Show("Zadejte jméno", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Name.Text.Any(c => char.IsDigit(c)) == true)
            {
                MessageBox.Show("Neplatné jméno.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (SurName.Text == "" || SurName.Text == null)
            {
                MessageBox.Show("Zadejte příjemní.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (SurName.Text.Any(c => char.IsDigit(c)) == true)
            {
                MessageBox.Show("Neplatné příjmení.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Gender.Text == "--Vyberte--")
            {
                MessageBox.Show("Vyberte pohlaví.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Int32.TryParse(RodneCislo1.Text, out x) == false || RodneCislo1.Text.ToString().Length != 6)
            {
                MessageBox.Show("Neplatné rodné číslo.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Int32.TryParse(RodneCislo2.Text, out x) == false || RodneCislo2.Text.ToString().Length != 4)
            {
                MessageBox.Show("Neplatné rodné číslo.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (BirthDate.Text == "" || BirthDate.Text == null)
            {
                MessageBox.Show("Zadejte datum narození.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                TodoItem item = new TodoItem();
                item.Name = Name.Text;
                item.SurName = SurName.Text;
                item.RodneCislo = RodneCislo1.Text + RodneCislo2.Text;
                item.Gender = Gender.Text;
                //var inMyString = BirthDate.SelectedDate.Value.ToShortDateString();
                item.BirthDate = BirthDate.SelectedDate.Value;
                item.Added = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                item.Edited = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                Database.SaveItemAsync(item);

                var itemsFromDb = Database.GetItemsAsync().Result;

                listwiew.ItemsSource = itemsFromDb;

            }
        }
    }
}

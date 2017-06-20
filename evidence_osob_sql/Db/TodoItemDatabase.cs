using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Text.RegularExpressions;

namespace evidence_osob_sql
{
    public class TodoItemDatabase
    {
        private SQLiteAsyncConnection database;
        public TodoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoItem>().Wait();
            database.CreateTableAsync<Category>().Wait();
            database.CreateTableAsync<CategoryItem>().Wait();
        }
        public Task<List<TodoItem>> GetItemsAsync()
        {
            return database.Table<TodoItem>().ToListAsync();
        }
        public Task<List<CategoryItem>> GetCatItemsAsync()
        {
            return database.Table<CategoryItem>().ToListAsync();
        }
        public Task<List<CategoryItem>> GetCatItemsAsyncbyItemID(int id)
        {
            return database.Table<CategoryItem>().Where(i => i.ID_TodoItem == id).ToListAsync();
        }
        public Task<List<Category>> GetCategoriesAsync()
        {
            return database.Table<Category>().ToListAsync();
        }

        public Task<List<Category>> GetCategoriesByIdAsync(int id)
        {
            return database.Table<Category>().Where(i => i.Id == id).ToListAsync();
        }

        public Task<Category> GetCategoryByIdAsync(int id)
        {
            return database.Table<Category>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveItemAsync(Category item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> SaveItemAsync(CategoryItem item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        /*public Task<TodoItem> GetItemAsync(string ISBN)
        {
            return database.Table<TodoItem>().Where(i => i.ISBN == ISBN).FirstOrDefaultAsync();
        }*/

        /*public Task<List<TodoItem>> GetItemAsync(string value) ////////////////////////////////////////////////////////////////
        {
            if(value == "" || value == null)
            {
                return database.Table<TodoItem>().ToListAsync();
            }
            bool m = Regex.IsMatch(value, @"\d");
            //return database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }*/

        public Task<int> SaveItemAsync(TodoItem item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> DeleteItemAsync(TodoItem item)
        {
            return database.DeleteAsync(item);
        }

        public Task<int> DeleteItemAsync(CategoryItem item)
        {
            return database.DeleteAsync(item);
        }

        public Task<TodoItem> GetIdbyName(string Name)
        {
            return database.Table<TodoItem>().Where(i => i.Name == Name).FirstOrDefaultAsync();
        }
    }
}

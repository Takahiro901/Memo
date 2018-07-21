using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Memo.Database
{
    public class TodoItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TodoItemDatabase()
        {
            database = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetPath());
            database.CreateTableAsync<TodoItem>().Wait();
        }

        public Task<List<TodoItem>> GetItemsAsync()
        {
            return database.Table<TodoItem>().ToListAsync();
        }

        public Task<int>  InsertItemsAsync(TodoItem item)
        {
            return database.InsertAsync(item);
        }

        public Task<int> UpdateItemsAsync(TodoItem item)
        {
            return database.UpdateAsync(item);
        }

        public Task<int> DeleteItemsAsync(TodoItem item)
        {
            return database.DeleteAsync(item);
        }

        /*
        static readonly object wObject = new object();
        readonly SQLiteConnection wTodoItemDatabase; 

        public TodoItemDatabase()
        {
            wTodoItemDatabase = DependencyService.Get<IFileHelper>().GetConnection();
            wTodoItemDatabase.CreateTable<TodoItem>();
        }

        public IEnumerable<TodoItem> GetItems()
        {
            lock (wObject)
            {
                return wTodoItemDatabase.Table<TodoItem>();
            }
        }

        public void InsertItem(TodoItem item)
        {
            lock(wObject)
            {
                wTodoItemDatabase.Insert(item);
            }
        }

        public void UpdateItem(TodoItem item)
        {
            lock (wObject)
            {
                wTodoItemDatabase.Update(item);
            }
        }

        public void DeleteItem(TodoItem item)
        {
            lock(wObject)
            {
                wTodoItemDatabase.Delete(item);
            }
        }
        */
    }
}

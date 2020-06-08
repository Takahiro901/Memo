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

        
    }
}

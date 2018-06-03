using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Memo.Database
{
    public class TodoItemDatabase
    {
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

        public void DeleteItem(TodoItem item)
        {
            lock(wObject)
            {
                wTodoItemDatabase.Delete(item);
            }
        }
    }
}

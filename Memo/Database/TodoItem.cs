using System;
using SQLite;

namespace Memo.Database
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Memo { get; set; }
        public DateTime InsertDate { get; set; }
    }
}

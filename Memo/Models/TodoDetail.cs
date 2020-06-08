using System;
using SQLite;

namespace Memo.Models
{
    public class TodoDetail
    {
        [PrimaryKey,AutoIncrement]
        public int Detail_Id { get; set; }

        public string DetailText { get; set; }

        public int Memo_Id { get; set; }
    }
}

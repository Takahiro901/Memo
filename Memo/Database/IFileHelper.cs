using System;
using SQLite;

namespace Memo.Database
{
    public interface IFileHelper
    {
        SQLiteConnection GetConnection();
    }
}

using System;
using System.IO;
using Memo.Droid;
using Memo.Database;
using Xamarin.Forms;
using SQLite;

[assembly: Dependency(typeof(FileHelper))]

namespace Memo.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetPath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "database.db3");
        }
        /*
        public SQLiteConnection GetConnection()
        {
            var wSqlitePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            const string wSqliteName = "SampleSQLite.db";

            var wPath = Path.Combine(wSqlitePath, wSqliteName);

            return new SQLiteConnection(wPath);

        }
        */
    }
}

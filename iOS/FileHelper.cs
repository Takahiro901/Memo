using System;
using System.IO;
using Memo.iOS;
using Memo.Database;
using Xamarin.Forms;
using SQLite;

[assembly: Dependency(typeof(FileHelper))]

namespace Memo.iOS
{
    public class FileHelper : IFileHelper
    {
        public SQLiteConnection GetConnection()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            return new SQLiteConnection(libFolder);

        }
    }
}

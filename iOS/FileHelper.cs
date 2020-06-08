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
        public string GetPath()
        {
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
            "..",
            "Library",
                "Databases");
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return Path.Combine(path, "database.db3");
        }
    }
}

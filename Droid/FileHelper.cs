using System;
using System.IO;
using Memo.Droid;
using Memo.Database;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]

namespace Memo.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}

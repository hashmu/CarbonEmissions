using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarbonEmissions.Models
{
    class DataManager
    {
        public DataManager()
        {
            FileUpdated(new string[] { Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Data") });
        }

        FileSystemWatcher watcher = new FileSystemWatcher();

        public void FileUpdated(string[] args)
        {
            watcher.Path = args[0];

            // Watch for changes in LastAccess and LastWrite times, and
            // the renaming of files or directories.
            watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;

            // Only watch text files.
            watcher.Filter = "test.txt";

            // Add event handlers.
            watcher.Changed += OnChanged;
            //watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            //watcher.Renamed += OnRenamed;

            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            System.Windows.MessageBox.Show($"File: {e.FullPath} {e.ChangeType}");
        }
    }
}

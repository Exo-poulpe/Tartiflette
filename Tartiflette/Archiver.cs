using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Compression;
using System.IO;

namespace Tartiflette
{
    class Archiver
    {
        private string _archiveName = string.Empty;
        ZipArchive _archive;
        private List<FileInfo> _files = new List<FileInfo>();

        string _appdata = Environment.GetEnvironmentVariable("appdata");
        public string ArchiveName { get => _archiveName; set => _archiveName = value; }
        private ZipArchive Archive { get => _archive; set => _archive = value; }
        public List<FileInfo> Files { get => _files; set => _files = value; }
        public string Appdata { get => _appdata;}

        public Archiver(string nameArchive)
        {
            
            string fullPath = $@"{Appdata}\Tarte\{nameArchive}";
            this.ArchiveName = fullPath;
            CreateArchive(fullPath);
        }


        private void CreateArchive(string name)
        {
            //File.Create(name).Close();
            if (Directory.Exists($@"{Appdata}\Tarte\"))
            {
                if (File.Exists(name))
                {
                    File.Delete(name);
                }
            }else
            {
                Directory.CreateDirectory($@"{Appdata}\Tarte\");
            }
            this.Archive = ZipFile.Open(name, ZipArchiveMode.Create);
            this.Archive.Dispose();
        }

        public void AddToArchive(FileInfo file)
        {
            this.Archive = ZipFile.Open(this.ArchiveName, ZipArchiveMode.Update);
            this.Archive.CreateEntryFromFile(file.FullName, file.Name, CompressionLevel.Optimal);
            this.Archive.Dispose();
        }

        public void AddToArchive(List<FileInfo> files)
        {
            foreach (var file in files)
            {
                this.AddToArchive(file);
            }
        }

        public void EventFileList()
        {
            List<FileInfo> tmp;
            while (true)
            {
                int cnt = this.Files.Count;
                if (cnt > 0)
                {
                    tmp = this.Files.GetRange(0, cnt);
                    this.Files.RemoveRange(0,cnt);
                    this.AddToArchive(tmp);
                    tmp = null;
                }
            }
        }
    }
}

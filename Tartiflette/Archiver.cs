﻿using System;
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
        public string ArchiveName { get => _archiveName; set => _archiveName = value; }
        private ZipArchive Archive { get => _archive; set => _archive = value; }

        public Archiver(string nameArchive)
        {
            this.ArchiveName = nameArchive;
            CreateArchive(this.ArchiveName);
        }


        private void CreateArchive(string name)
        {
            //File.Create(name).Close();
            if (File.Exists(name))
            {
                File.Delete(name);
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
    }
}
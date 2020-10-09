using DesktopMode.Saved_Configs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsDesktop;

namespace DesktopMode
{
    public partial class Form1 : Form
    {
        string[] args = Environment.GetCommandLineArgs();
        VirtualDesktop[] allDesktops = new VirtualDesktop[10];
        public Form1()
        {
            InitializeComponent();
        }

        private void FORM1_Load(object sender, EventArgs e)
        {
            VirtualDesktop.GetDesktops().CopyTo(allDesktops, 0);
            if (args.Length > 1)
            {
                if(args[1] == "-ARGS")
                {
                    allDesktops[1] = VirtualDesktop.Create();
                    allDesktops[1].Switch();
                    Application.Exit();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(allDesktops[1] == null)
            {
                DesktopConfig DC = new DesktopConfig("newConfig", "Arg");
                DC.CreateNewConfig();
                DC.Load();
            }
            //allDesktops[1].Switch();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

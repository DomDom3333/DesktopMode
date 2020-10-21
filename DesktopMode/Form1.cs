using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DesktopMode
{
    public partial class Form1 : Form
    {
        private const int MAXMODES = 100;
        private string[] modes = new string[MAXMODES];
        private int numModes = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Settings.Default.modesLocation);
        }

        private void readAllModes()
        {
            string[] inputModes = Properties.Settings.Default.allModes.Split(',');
            numModes = inputModes.Length;
            inputModes.CopyTo(modes, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tb_NewModePath.Text = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            if ((Properties.Settings.Default.firstStartup == true) || Properties.Settings.Default.modesLocation == "")
            {
                Setup form = new Setup();
                form.ShowDialog();
                //MessageBox.Show("One day, there shall be a install scirpt here. Until then you may continiue.");
                //Properties.Settings.Default.firstStartup = false;
                //Properties.Settings.Default.modesLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            }
            else
            {
                readAllModes();
                MessageBox.Show("Welcome back!");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }


        private void newMode()
        {

        }
        private void mapNewMode(string path)
        {
            string name = new DirectoryInfo(path).Name;
            if (checkIfModeExists(name))
            {
                MessageBox.Show("This Mode already exists or that name is taken. Please use another name.");
                return;
            }
            addModeToArray(name);
            //createShortcut    (Generate Shortcut to mode)
            //distroShortcut    (Copy shortcut to all Modes)
            updateAllModes();
        }
        private void addModeToArray(string name)
        {
            int index = 0;
            for(int i = 0; modes[i] != ""; i++)
            {
                index++;
            }
            modes[index+1] = name;
        }
        private bool checkIfModeExists(string name)
        {
            return modes.Contains(name);
        }
        private void updateAllModes()
        {
            string allModes = "";
            for(int i = 0; i < modes.Length; i++)
            {
                allModes += modes[i];
                if (i + 1 < modes.Length)
                {
                    allModes += ",";
                }
            }
        }
        private void bt_MapNew_Click(object sender, EventArgs e)
        {
            if ((numModes + 1) < MAXMODES)
            {
                string path = "";
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    path = folderBrowserDialog1.SelectedPath;
                    if (Directory.Exists(path))
                    {
                        mapNewMode(path);
                    }
                }
            }      
        }
    }
}

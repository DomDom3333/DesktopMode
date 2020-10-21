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
    public partial class frm_Main : Form
    {
        private const int MAXMODES = 100;
        private string[] modes = new string[MAXMODES];
        private int numModes = 0;
        public frm_Main()
        {
            InitializeComponent();
        }

//----------[ UI Methods ] ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void bt_openModesLocation_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Settings.Default.modesLocation);
        }
        private void frm_Main_Load(object sender, EventArgs e)
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

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
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


//----------[ Custom Methods ] ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private void newMode()
        {

        }
        private void mapNewMode(string path)
        {
            string folderName = new DirectoryInfo(path).Name;
            string name = "NewTest";
            if (checkIfModeExists(name))
            {
                MessageBox.Show("This Mode already exists or that name is taken. Please use another name.");
                return;
            }
            addModeToArray(name);
            Directory.Move(path, Properties.Settings.Default.modesLocation + "\\" + name);
            createShortcut(name + " Mode", Properties.Settings.Default.ShortcutCollection, System.Reflection.Assembly.GetExecutingAssembly().Location);
            updateAllModes();
        }

        private void switchMode()
        {
            //grab all items on Desktop.
            //Filter out the Mode Shortcuts.
            //Delete Mode Shortcuts
            //Copy Remaining items to corresponding mode folder
            //Populate Desktop with content of new Mode folder
            //Copy Shortcuts out of Shortcut folder
        }

        //----------[ Support Methods ] ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void createShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "This shortcut takes you to your " + shortcutName;   // The description of the shortcut
            shortcut.TargetPath = targetFileLocation;                 // The path of the file that will launch when the shortcut is run
            shortcut.Save();                                    // Save the shortcut
        }
        private void addModeToArray(string name)
        {
            int index = 0;
            for (int i = 0; modes[i] != null; i++)
            {
                index++;
            }
            modes[index] = name;
        }
        private bool checkIfModeExists(string name)
        {
            return modes.Contains(name);
        }
        private void readAllModes()
        {
            string[] inputModes = Properties.Settings.Default.allModes.Split(',');
            numModes = inputModes.Length;
            inputModes.CopyTo(modes, 0);
        }
        private void updateAllModes()
        {
            string allModes = "";
            for (int i = 0; i < modes.Length; i++)
            {
                allModes += modes[i];
                if (i + 1 < modes.Length)
                {
                    allModes += ",";
                }
            }
        }

        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}

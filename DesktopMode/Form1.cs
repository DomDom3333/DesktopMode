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
            string[] args = Environment.GetCommandLineArgs();
            if ((Properties.Settings.Default.firstStartup == true) || Properties.Settings.Default.modesLocation == "")
            {
                Setup form = new Setup();
                form.ShowDialog();
                string[] toDoFromSetup = Properties.Settings.Default.SetupHelper.Split(',');
                //Helper from setup menu. If [1] = 1 then BackupMode shortuct needs to be added to desktop. If not, Mode with name of [0] gets created without Shortcut. If .Length is 0 then 
                //This ist to create a backup of the current user Desktop in case something goes wrong or missing.
                if (toDoFromSetup[0] != "")
                {
                    tb_NewModeName.Text = toDoFromSetup[0];
                    if (toDoFromSetup[1] == "1") 
                    {
                        newMode();
                    }
                    else
                    {
                        newMode(false);
                    }
                }
                tb_NewModeName.Text = "";
            }
            else
            {
                readAllModes();
                if (args.Length > 1 && args[1] != null)
                {
                    if (modes.Contains(args[1]))
                    {
                        switchMode(args[1]);
                    }
                    else
                    {
                        MessageBox.Show("Mode does not exist or is not registerd. Recreate the Mode or Map one with that name.");
                    }
                }
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


        private void newMode(bool addToDesktop = true)
        {
            if(numModes >= 100)
            {
                MessageBox.Show("You have reached the macimum number of modes. Please Delete some to create a new one.", "Too many modes!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult sure = MessageBox.Show("This will create a new mode based on what is CURRENTLY on your Desktp. It will have the name: " + tb_NewModeName.Text + "\n Are you sure you want to continiue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(sure == DialogResult.No)
            {
                return;
            }
            string newModeName = tb_NewModeName.Text;
            Directory.CreateDirectory(Properties.Settings.Default.allModes + "\\" + newModeName);
            addModeToArray(newModeName);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string[] files = Directory.GetFiles(desktopPath);
            deleteModeShortcutsFromPath();
            CopyFolderContents(desktopPath, Properties.Settings.Default.allModes + "\\" + newModeName);
            if (addToDesktop)
            {
                createShortcut(newModeName + " Mode", Properties.Settings.Default.ShortcutCollection, System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
            CopyFolderContents(Properties.Settings.Default.ShortcutCollection, desktopPath);
            Properties.Settings.Default.currentMode = newModeName;
        }
        private void mapNewMode(string path)
        {
            if (numModes >= 100)
            {
                MessageBox.Show("You have reached the macimum number of modes. Please Delete some to create a new one.", "Too many modes!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string folderName = new DirectoryInfo(path).Name;
            string name = tb_NewModeName.Text;
            if (checkIfModeExists(name))
            {
                MessageBox.Show("This Mode already exists or that name is taken. Please use another name.");
                return;
            }
            addModeToArray(name);
            Directory.Move(path, Properties.Settings.Default.modesLocation + "\\" + name);
            createShortcut(name, Properties.Settings.Default.ShortcutCollection, System.Reflection.Assembly.GetExecutingAssembly().Location);
            updateAllModes();
        }

        private void switchMode(string switchTo)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            deleteModeShortcutsFromPath(); //Filter and Delete mode Shortcuts from Desktop (desktop = Default Value)
            CopyFolderContents(desktopPath, Properties.Settings.Default.allModes + "\\" + Properties.Settings.Default.currentMode); //copy Desktop to Mode Folder
            deleteAllFilesFromPath(desktopPath); //clear Desktop
            CopyFolderContents(Properties.Settings.Default.allModes + "\\" + switchTo, desktopPath); //populate Desktop with new mode
            CopyFolderContents(Properties.Settings.Default.ShortcutCollection, desktopPath); //Add shortcuts
            Properties.Settings.Default.currentMode = switchTo;
        }

        //----------[ Support Methods ] ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void createShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk -" + shortcutName);
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "This shortcut takes you to your " + shortcutName;   // The description of the shortcut
            shortcut.TargetPath = targetFileLocation;                                   // The path of the file that will launch when the shortcut is run
            shortcut.Save();                                                            // Save the shortcut
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
        private bool checkIfModFolderExists(string name)
        {
            return Directory.Exists(Properties.Settings.Default.allModes + "\\" + name);
        }
        private void readAllModes()
        {
            string[] inputModes = Properties.Settings.Default.allModes.Split(',');
            numModes = inputModes.Length;
            for(int i = 0; i < inputModes.Length; i++){
                if (checkIfModFolderExists(inputModes[i]))
                {
                    modes[i] = inputModes[i];
                }
            }
            inputModes.CopyTo(modes, 0);
        }
        private void updateAllModes()
        {
            string allModes = "";
            for (int i = 0; i < modes.Length; i++)
            {
                if (checkIfModFolderExists(modes[i]) & File.Exists(Properties.Settings.Default.ShortcutCollection + modes[i] + ".lnk"))
                {
                    allModes += modes[i];
                    if (i + 1 < modes.Length)
                    {
                        allModes += ",";
                    }
                }
                else if (checkIfModFolderExists(modes[i]) & !File.Exists(Properties.Settings.Default.ShortcutCollection + modes[i] + ".lnk"))
                {
                    MessageBox.Show("A mode folder was found without linked appropriate mode shortcut. Shortcut was created. If you wanted to delete the mode, please delete the folder.", "Shortcut not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    createShortcut(modes[i], Properties.Settings.Default.ShortcutCollection, System.Reflection.Assembly.GetExecutingAssembly().Location);
                    allModes += modes[i];
                    if (i + 1 < modes.Length)
                    {
                        allModes += ",";
                    }
                }
                else if (!checkIfModFolderExists(modes[i]) & File.Exists(Properties.Settings.Default.ShortcutCollection + modes[i] + ".lnk"))
                {
                    MessageBox.Show("A mode shortcut was found without linked appropriate mode folder. Shortcut was deleted. If you want to recreate the mode, please remap the Folder.", "Folder not found", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    File.Delete(Properties.Settings.Default.ShortcutCollection + modes[i] + ".lnk");
                }
            }
        }
        private void deleteAllFilesFromPath(string path)
        {
            string[] files = Directory.GetFiles(path);
            for (int i = 0; i < files[i].Length; i++)
            {
                if (File.Exists(files[i]))
                {
                    File.Delete(files[i]);
                }
            }
        }
        private void deleteModeShortcutsFromPath(string path = "")
        {
            if(path == "")
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            for (int i = 0; modes[i] != null; i++)
            {
                if (File.Exists(path + modes[i] + ".lnk"))
                {
                    File.Delete(path + modes[i] + ".lnk");
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
        public static void CopyFolderContents(string sourceFolder, string destinationFolder)
        {
            if (Directory.Exists(sourceFolder))
            {
                // Copy folder structure
                foreach (string sourceSubFolder in Directory.GetDirectories(sourceFolder, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(sourceSubFolder.Replace(sourceFolder, destinationFolder));
                }

                // Copy files
                foreach (string sourceFile in Directory.GetFiles(sourceFolder, "*", SearchOption.AllDirectories))
                {
                    string destinationFile = sourceFile.Replace(sourceFolder, destinationFolder);
                    File.Copy(sourceFile, destinationFile, true);
                }
            }
        }
    }
}

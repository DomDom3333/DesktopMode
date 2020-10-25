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
        private void tb_NewModeName_TextChanged(object sender, EventArgs e)
        {
            tb_NewModeName.Text = replaceSpaces(tb_NewModeName.Text);
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
                    //similar to newMode(), this just creates a folder of current desktop contents without adding it to mode list
                    string newModeName = toDoFromSetup[0];
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    Directory.CreateDirectory(Properties.Settings.Default.modesLocation + "\\" + newModeName);
                    deleteModeShortcutsFromPath();
                    CopyFolderContents(desktopPath, Properties.Settings.Default.modesLocation + "\\" + newModeName);
                    tb_NewModeName.Text = "";
                    MessageBox.Show("A Backup Folder was created at the location of the other Modes, in case something goes wrong.", "Backup folder created.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                Properties.Settings.Default.firstStartup = false;
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
            }
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            shutDown();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void bt_Help_Click(object sender, EventArgs e)
        {
            HelpMenu form = new HelpMenu();
            form.ShowDialog();
        }
        private void bt_MapNew_Click(object sender, EventArgs e)
        {
            mapNewMode(); 
        }
        private void bt_CreateNew_Click(object sender, EventArgs e)
        {
            newMode();
        }


        //----------[ Custom Methods ] ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private void newMode(bool addToDesktop = true)
        {
            if (!checkIfValid())
            {
                return;
            }
            DialogResult sure = MessageBox.Show("This will create a new mode based on what is CURRENTLY on your Desktp. It will have the name: " + tb_NewModeName.Text + "\n Are you sure you want to continiue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(sure == DialogResult.No)
            {
                return;
            }
            string newModeName = tb_NewModeName.Text;
            newModeName = replaceSpaces(newModeName);
            tb_NewModeName.Text = newModeName;
            Directory.CreateDirectory(Properties.Settings.Default.modesLocation + "\\" + newModeName);
            addModeToArray(newModeName);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            deleteModeShortcutsFromPath();
            CopyFolderContents(desktopPath, Properties.Settings.Default.modesLocation + "\\" + newModeName);
            if (addToDesktop)
            {
                createShortcut(newModeName, Properties.Settings.Default.ShortcutCollection, System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
            CopyFolderContents(Properties.Settings.Default.ShortcutCollection, desktopPath);
            Properties.Settings.Default.currentMode = newModeName;
            numModes++;
        }
        private void mapNewMode(bool addToDesktop = true)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            string path = folderBrowserDialog1.SelectedPath;
            if (!Directory.Exists(path))
            {
                return;
            }
            if (!checkIfValid())
            {
                return;
            }
            string name = tb_NewModeName.Text;
            addModeToArray(name);
            Directory.Move(path, Properties.Settings.Default.modesLocation + "\\" + name);
            if (addToDesktop)
            {
                createShortcut(name, Properties.Settings.Default.ShortcutCollection, System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
            updateAllModes();
            numModes++;
        }

        private void switchMode(string switchTo)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            deleteModeShortcutsFromPath(); //Filter and Delete mode Shortcuts from Desktop (desktop = Default Value)
            CopyFolderContents(desktopPath, Properties.Settings.Default.modesLocation + "\\" + Properties.Settings.Default.currentMode); //copy Desktop to Mode Folder
            deleteAllFilesFromPath(desktopPath); //clear Desktop
            CopyFolderContents(Properties.Settings.Default.modesLocation + "\\" + switchTo, desktopPath); //populate Desktop with new mode
            CopyFolderContents(Properties.Settings.Default.ShortcutCollection, desktopPath); //Add shortcuts
            Properties.Settings.Default.currentMode = switchTo;
        }
        private void shutDown()
        {
            if(Properties.Settings.Default.firstStartup == false)
            {
                saveAll();
            }
        }

        //----------[ Support Methods ] ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private bool checkIfValid()
        {
            if (numModes >= MAXMODES)
            {
                MessageBox.Show("You have reached the macimum number of modes. Please Delete some to create a new one.", "Too many modes!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (tb_NewModeName.Text == "")
            {
                MessageBox.Show("Please enter a name for first.", "Name Needed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (checkIfModeExists(tb_NewModeName.Text))
            {
                MessageBox.Show("This mode already exists. Please give it another name.", "Mode already exists!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private string replaceSpaces(string input)
        {
            return input.Replace(' ', '_');
        }
        private void saveAll()
        {
            updateAllModes();
            Properties.Settings.Default.Save();
        }
        private void createShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "This shortcut takes you to your " + shortcutName;           // The description of the shortcut
            shortcut.TargetPath = targetFileLocation;                                           // The path of the file that will launch when the shortcut is run
            shortcut.Arguments = shortcutName;                                                  // Adds schortcut arguments
            shortcut.IconLocation = System.Reflection.Assembly.GetExecutingAssembly().Location; // Sets icon Location to own EXE
            shortcut.Save();                                                                    // Save the shortcut
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
        private bool checkIfModeFolderExists(string name)
        {
            return Directory.Exists(Properties.Settings.Default.modesLocation + "\\" + name);
        }
        private void readAllModes()
        {
            string[] inputModes = Properties.Settings.Default.allModes.Split(',');
            numModes = inputModes.Length;
            for(int i = 0; i < inputModes.Length; i++){
                if (checkIfModeFolderExists(inputModes[i]))
                {
                    modes[i] = inputModes[i];
                }
            }
            inputModes.CopyTo(modes, 0);
        }
        private void updateAllModes()
        {
            updateShortcutBin();
            string allModes = "";
            for (int i = 0; i < modes.Length; i++)
            {
                if (modes[i] == null || modes[i] == "")
                {
                    continue;
                }
                if (checkIfModeFolderExists(modes[i]) & File.Exists(Properties.Settings.Default.ShortcutCollection + "\\" + modes[i] + ".lnk"))
                {
                    if (modes[i] != "")
                    {
                        allModes += modes[i];
                        if (i + 1 < modes.Length)
                        {
                            allModes += ",";
                        }
                    }
                }
                else if (checkIfModeFolderExists(modes[i]) & !File.Exists(Properties.Settings.Default.ShortcutCollection + "\\" + modes[i] + ".lnk"))
                {
                    MessageBox.Show("A mode folder was found without linked appropriate mode shortcut. Shortcut was created. If you wanted to delete the mode, please delete the folder.", "Shortcut not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    createShortcut(modes[i], Properties.Settings.Default.ShortcutCollection, System.Reflection.Assembly.GetExecutingAssembly().Location);
                    allModes += modes[i];
                    if (i + 1 < modes.Length)
                    {
                        allModes += ",";
                    }
                }
                else if (!checkIfModeFolderExists(modes[i]) & File.Exists(Properties.Settings.Default.ShortcutCollection + "\\" + modes[i] + ".lnk"))
                {
                    MessageBox.Show("A mode shortcut was found without linked appropriate mode folder. Shortcut was deleted. If you want to recreate the mode, please remap the Folder.", "Folder not found", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    File.Delete(Properties.Settings.Default.ShortcutCollection + modes[i] + ".lnk");
                }
            }
        }
        private void updateShortcutBin()
        {
            string[] files = Directory.GetFiles(Properties.Settings.Default.ShortcutCollection);
            if (files == null){
                return;
            }
            for (int i = 0; i < files.Length; i++)
            {
                if (!checkIfModeExists(Path.GetFileNameWithoutExtension(files[i])) || !checkIfModeFolderExists(Path.GetFileNameWithoutExtension(files[i])))
                {
                    File.Delete(files[i]);
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
        public static void Copy(string sourceDirectory, string targetDirectory) //this copies the entire folder
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
        public static void CopyFolderContents(string sourceFolder, string destinationFolder) //this only copies the folder contents
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

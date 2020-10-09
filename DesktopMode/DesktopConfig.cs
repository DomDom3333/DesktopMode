using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WindowsDesktop;
using Shell32;
using IWshRuntimeLibrary;

namespace DesktopMode.Saved_Configs
{
    class DesktopConfig
    {
        private string PATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public string name { get; set; }
        public string argument { get; set; }

        private Shortcut[] cuts;

        public DesktopConfig(string newName, string newArgument) //constructor
        {
            name = newName;
            argument = newArgument;
        }
        
        public void CloseConfig()
        {
            Save();
            Clear();
        }

        public void OpenConfig()
        {
            Load();
            Show();
        }

        public void CreateNewConfig()
        {
            InitializeShortcutArray(FindAlllShorcuts());
        }
        public Shortcut[] getShortcuts()
        {
            return cuts;
        }
        private void InitializeShortcutArray(string[] SCs)
        {
            int count = SCs.Length;

            cuts = new Shortcut[count];

            for (int i = 0; i < count; i++)
            {
                cuts[i] = new Shortcut(SCs[i], Path.GetFileName(SCs[i]));
            }
        }
        private string[] FindAlllShorcuts()
        {
            string[] allFiles = Directory.GetFiles(PATH);
            string[] tempSCs = new string[allFiles.Length];
            int sendto = 0;
            foreach (string file in allFiles)
            {
                if(Path.GetExtension(file) == ".lnk")
                {
                    tempSCs[sendto] = file;
                    sendto++;
                }
            }

            string[] SCs = new string[sendto];
            for (int i = 0; i < sendto; i++)
            {
                SCs[i] = tempSCs[i];
            }

            return SCs;


        }
        public void Load()
        {
            WriteShortcut(cuts[2]);
        }

        private void Clear() //clear curent config from desktop (prep for next config)
        {
            foreach (Shortcut SC in cuts)
            {
                DeleteShortcut(SC);
            }
        }
        private void Show() //show new config
        {
            foreach(Shortcut SC in cuts)
            {
                WriteShortcut(SC);
            }
        }

        private void Save()
        {

        }

        private void RemoveShortcut() //remove from cuts[]
        {

        }
        private void AddShortcut() //add to cuts[]
        {

        }

        private void WriteShortcut(Shortcut SC) //write to Desktop
        {
            string shortcutLocation = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(SC.path) + "\\DEBUG " + SC.name);
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = SC.comment;   // The description of the shortcut
            shortcut.WorkingDirectory = SC.startIn;
            if(SC.icon == "")
            {
                shortcut.IconLocation = SC.target;           // The icon of the shortcut
            }
            else
            {
                shortcut.IconLocation = SC.icon;           // The icon of the shortcut
            }
            shortcut.TargetPath = SC.target;                 // The path of the file that will launch when the shortcut is run
            shortcut.Save();
        }
        private void DeleteShortcut(Shortcut SC) //delete from Desktop
        {
            System.IO.File.Delete(SC.path);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------
        // Helper Methodes

    }

}

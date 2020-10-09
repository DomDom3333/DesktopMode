using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Shell32;
using System.Drawing;

namespace DesktopMode
{
    class Shortcut
    {
        Shell shl = new Shell();         // Move this to class scope

        public string name { get; set; }
        public string target { get; set; }
        public string startIn { get; set; }
        public string argument { get; set; }
        public string shortcutKey { get; set; }
        public string runAs { get; set; }
        public string comment { get; set; }
        public string icon { get; set; }
        public bool runAsAdmin { get; set; }
        public string path { get; set; }




        public Shortcut(string newPath, string newName, string newStartIn = "", string newArgument = "", string newShourtcutKey = "", string newRunAs = "", string newComment = "", string newIcon = "", bool newRunAsAdmin = false)
        {
            name = newName;
            target = GetShortcutTargetFile(newPath);
            if(newStartIn == "")
            {
                startIn = Path.GetDirectoryName(target);
            }
            else
            {
                startIn = newStartIn;
            }
            argument = newArgument;
            shortcutKey = newShourtcutKey;
            runAs = newRunAs;
            comment = newComment;
            icon = GetShortcutIconFile(newPath);
            runAsAdmin = newRunAsAdmin;
            path = newPath;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------
        // Helper Methodes

        //copied out of the internet and supposedly returns more info about a shortcut file. needs using shell32 to work
        public string GetShortcutTargetFile(string shortcutFilename)
        {
            string pathOnly = System.IO.Path.GetDirectoryName(shortcutFilename);
            string filenameOnly = System.IO.Path.GetFileName(shortcutFilename);

            Shell32.Shell shell = new Shell32.ShellClass();
            Shell32.Folder folder = shell.NameSpace(pathOnly);
            Shell32.FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                Shell32.ShellLinkObject link =
            (Shell32.ShellLinkObject)folderItem.GetLink;
                return link.Path;
            }
            return ""; // not found or target is empty/doesnt exist
        }
        public string GetShortcutIconFile(string lnkPath)
        {
            lnkPath = Path.GetFullPath(lnkPath);
            Folder dir = shl.NameSpace(Path.GetDirectoryName(lnkPath));
            FolderItem itm = dir.Items().Item(Path.GetFileName(lnkPath));
            var lnk = (ShellLinkObject)itm.GetLink;
            string strIcon;
            lnk.GetIconLocation(out strIcon);
            //Icon awIcon = Icon.ExtractAssociatedIcon(strIcon);
            return strIcon;
        }
    }
}

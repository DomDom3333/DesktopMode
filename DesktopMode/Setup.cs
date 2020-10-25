using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopMode
{
    public partial class Setup : Form
    {
        public Setup()
        {
            InitializeComponent();
        }

        private void bt_Next_Click(object sender, EventArgs e)
        {
            if (tbc_Setup.SelectedIndex < tbc_Setup.TabCount)
            {
                tbc_Setup.SelectedIndex++;
                bt_Prev.Enabled = true;
                if (tbc_Setup.SelectedIndex + 1 == tbc_Setup.TabCount)
                {
                    bt_Next.Enabled = false;
                }
            }
        }

        private void bt_Prev_Click(object sender, EventArgs e)
        {
            if(tbc_Setup.SelectedIndex > 0)
            {
                tbc_Setup.SelectedIndex--;
                bt_Next.Enabled = true;
                if (tbc_Setup.SelectedIndex == 0)
                {
                    bt_Prev.Enabled = false;
                }
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_Finish_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tb_SaveLocationPath.Text) & (tb_ModeName.Text != "" || cb_Skip.Checked))
            {
                if (!checkIfDirIsEmpty(tb_SaveLocationPath.Text))
                {
                    MessageBox.Show("Please select a VALID and EMPTY directory.", "Invalid Directory.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_SaveLocationPath.Text = "";
                    tbc_Setup.SelectedIndex = 1;
                    return;
                }
                if (cb_Skip.Checked == false)
                {
                    Properties.Settings.Default.SetupHelper = tb_ModeName.Text;

                }
                else
                {
                    DialogResult sure = MessageBox.Show("Are you sure you want to skip making a backup of your current Desktop? This is STRONGLY recommended!!", "ARE YOU SURE?!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (sure == DialogResult.No)
                    {
                        return;
                    }
                }
                Properties.Settings.Default.modesLocation = tb_SaveLocationPath.Text;
                Properties.Settings.Default.ShortcutCollection = Properties.Settings.Default.modesLocation + "\\SchortcutBin";
                Directory.CreateDirectory(Properties.Settings.Default.ShortcutCollection);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please make sure you have filled out all steps first.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!cb_Skip.Checked)
            {
                tb_ModeName.Enabled = true;
            }
            else if (cb_Skip.Checked)
            {
                tb_ModeName.Enabled = false;
            }
        }

        private void bt_ClearSave_Click(object sender, EventArgs e)
        {
            tb_SaveLocationPath.Text = "";
        }

        private void bt_BrowseSave_Click(object sender, EventArgs e)
        {
            DialogResult Result = folderBrowserDialog1.ShowDialog();
            if (Result == DialogResult.OK)
            {
                tb_SaveLocationPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private bool checkIfDirIsEmpty(string path)
        {
            if (Directory.Exists(path))
            {
                if (Directory.GetFileSystemEntries(path) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}

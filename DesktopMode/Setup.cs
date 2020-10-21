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

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbc_Setup.SelectedIndex < tbc_Setup.TabCount)
            {
                tbc_Setup.SelectedIndex++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tbc_Setup.SelectedIndex > 0)
            {
                tbc_Setup.SelectedIndex--;
            }
        }

        private void tb_ModeName_Clicked(object sender, EventArgs e)
        {
            tb_ModeName.Text = "";
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_Finish_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tb_SaveLocationPath.Text) && (tb_ModeName.Text != "" || cb_Skip.Checked))
            {
                Properties.Settings.Default.modesLocation = tb_SaveLocationPath.Text;
                Properties.Settings.Default.allModes += tb_ModeName.Text + ",";
                if (cb_Skip.Checked == false)
                {
                    if (cb_AddToDesktop.Checked)
                    {
                        Properties.Settings.Default.SetupHelper = tb_ModeName.Text + ",1";
                    }
                    else if (!cb_AddToDesktop.Checked)
                    {
                        Properties.Settings.Default.SetupHelper = tb_ModeName.Text + ",0";
                    }
                    string shortCutBinPath = Properties.Settings.Default.modesLocation + "\\SchortcutBin";
                    Directory.CreateDirectory(shortCutBinPath);
                    Properties.Settings.Default.ShortcutCollection = shortCutBinPath;
                }
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
                cb_AddToDesktop.Enabled = true;
            }
            else if (cb_Skip.Checked)
            {
                tb_ModeName.Enabled = false;
                cb_AddToDesktop.Enabled = false;
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
    }
}

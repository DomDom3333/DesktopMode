using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopMode
{
    public partial class HelpMenu : Form
    {
        public HelpMenu()
        {
            InitializeComponent();
        }

        private void bt_Prev_Click(object sender, EventArgs e)
        {
            if (tbc_help.SelectedIndex > 0)
            {
                tbc_help.SelectedIndex--;
                bt_Next.Enabled = true;
                if (tbc_help.SelectedIndex == 0)
                {
                    bt_Prev.Enabled = false;
                }
            }
        }

        private void bt_Next_Click(object sender, EventArgs e)
        {
            if (tbc_help.SelectedIndex < tbc_help.TabCount)
            {
                tbc_help.SelectedIndex++;
                bt_Prev.Enabled = true;
                if (tbc_help.SelectedIndex + 1 == tbc_help.TabCount)
                {
                    bt_Next.Enabled = false;
                }
            }
        }

        private void bt_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
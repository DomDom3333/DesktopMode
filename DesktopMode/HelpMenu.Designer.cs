namespace DesktopMode
{
    partial class HelpMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpMenu));
            this.tbc_help = new System.Windows.Forms.TabControl();
            this.tbp_Intro = new System.Windows.Forms.TabPage();
            this.tbp_MapNewMode = new System.Windows.Forms.TabPage();
            this.tb_Intro = new System.Windows.Forms.TextBox();
            this.bt_Next = new System.Windows.Forms.Button();
            this.bt_Prev = new System.Windows.Forms.Button();
            this.bt_Close = new System.Windows.Forms.Button();
            this.tb_MapNew = new System.Windows.Forms.TextBox();
            this.tbp_CreateNew = new System.Windows.Forms.TabPage();
            this.tbp_DeletingModes = new System.Windows.Forms.TabPage();
            this.tbp_TipsTricks = new System.Windows.Forms.TabPage();
            this.tb_CreateNew = new System.Windows.Forms.TextBox();
            this.tb_DeletingMode = new System.Windows.Forms.TextBox();
            this.tb_TippsTricks = new System.Windows.Forms.TextBox();
            this.tbc_help.SuspendLayout();
            this.tbp_Intro.SuspendLayout();
            this.tbp_MapNewMode.SuspendLayout();
            this.tbp_CreateNew.SuspendLayout();
            this.tbp_DeletingModes.SuspendLayout();
            this.tbp_TipsTricks.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbc_help
            // 
            this.tbc_help.Controls.Add(this.tbp_Intro);
            this.tbc_help.Controls.Add(this.tbp_CreateNew);
            this.tbc_help.Controls.Add(this.tbp_MapNewMode);
            this.tbc_help.Controls.Add(this.tbp_DeletingModes);
            this.tbc_help.Controls.Add(this.tbp_TipsTricks);
            this.tbc_help.Location = new System.Drawing.Point(12, 13);
            this.tbc_help.Name = "tbc_help";
            this.tbc_help.SelectedIndex = 0;
            this.tbc_help.Size = new System.Drawing.Size(429, 248);
            this.tbc_help.TabIndex = 0;
            // 
            // tbp_Intro
            // 
            this.tbp_Intro.Controls.Add(this.tb_Intro);
            this.tbp_Intro.Location = new System.Drawing.Point(4, 22);
            this.tbp_Intro.Name = "tbp_Intro";
            this.tbp_Intro.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_Intro.Size = new System.Drawing.Size(421, 222);
            this.tbp_Intro.TabIndex = 0;
            this.tbp_Intro.Text = "Desktop Mode Into";
            this.tbp_Intro.UseVisualStyleBackColor = true;
            // 
            // tbp_MapNewMode
            // 
            this.tbp_MapNewMode.Controls.Add(this.tb_MapNew);
            this.tbp_MapNewMode.Location = new System.Drawing.Point(4, 22);
            this.tbp_MapNewMode.Name = "tbp_MapNewMode";
            this.tbp_MapNewMode.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_MapNewMode.Size = new System.Drawing.Size(421, 222);
            this.tbp_MapNewMode.TabIndex = 1;
            this.tbp_MapNewMode.Text = "Mapping New Modes";
            this.tbp_MapNewMode.UseVisualStyleBackColor = true;
            // 
            // tb_Intro
            // 
            this.tb_Intro.Location = new System.Drawing.Point(7, 7);
            this.tb_Intro.Multiline = true;
            this.tb_Intro.Name = "tb_Intro";
            this.tb_Intro.ReadOnly = true;
            this.tb_Intro.Size = new System.Drawing.Size(408, 209);
            this.tb_Intro.TabIndex = 0;
            this.tb_Intro.TabStop = false;
            this.tb_Intro.Text = resources.GetString("tb_Intro.Text");
            // 
            // bt_Next
            // 
            this.bt_Next.Location = new System.Drawing.Point(366, 267);
            this.bt_Next.Name = "bt_Next";
            this.bt_Next.Size = new System.Drawing.Size(75, 23);
            this.bt_Next.TabIndex = 1;
            this.bt_Next.Text = "Next";
            this.bt_Next.UseVisualStyleBackColor = true;
            this.bt_Next.Click += new System.EventHandler(this.bt_Next_Click);
            // 
            // bt_Prev
            // 
            this.bt_Prev.Enabled = false;
            this.bt_Prev.Location = new System.Drawing.Point(12, 267);
            this.bt_Prev.Name = "bt_Prev";
            this.bt_Prev.Size = new System.Drawing.Size(75, 23);
            this.bt_Prev.TabIndex = 2;
            this.bt_Prev.Text = "Previous";
            this.bt_Prev.UseVisualStyleBackColor = true;
            this.bt_Prev.Click += new System.EventHandler(this.bt_Prev_Click);
            // 
            // bt_Close
            // 
            this.bt_Close.Location = new System.Drawing.Point(189, 267);
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.Size = new System.Drawing.Size(75, 23);
            this.bt_Close.TabIndex = 3;
            this.bt_Close.Text = "Close";
            this.bt_Close.UseVisualStyleBackColor = true;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            // 
            // tb_MapNew
            // 
            this.tb_MapNew.Location = new System.Drawing.Point(7, 7);
            this.tb_MapNew.Multiline = true;
            this.tb_MapNew.Name = "tb_MapNew";
            this.tb_MapNew.ReadOnly = true;
            this.tb_MapNew.Size = new System.Drawing.Size(408, 209);
            this.tb_MapNew.TabIndex = 1;
            this.tb_MapNew.TabStop = false;
            this.tb_MapNew.Text = resources.GetString("tb_MapNew.Text");
            // 
            // tbp_CreateNew
            // 
            this.tbp_CreateNew.Controls.Add(this.tb_CreateNew);
            this.tbp_CreateNew.Location = new System.Drawing.Point(4, 22);
            this.tbp_CreateNew.Name = "tbp_CreateNew";
            this.tbp_CreateNew.Size = new System.Drawing.Size(421, 222);
            this.tbp_CreateNew.TabIndex = 2;
            this.tbp_CreateNew.Text = "Creating New Modes";
            this.tbp_CreateNew.UseVisualStyleBackColor = true;
            // 
            // tbp_DeletingModes
            // 
            this.tbp_DeletingModes.Controls.Add(this.tb_DeletingMode);
            this.tbp_DeletingModes.Location = new System.Drawing.Point(4, 22);
            this.tbp_DeletingModes.Name = "tbp_DeletingModes";
            this.tbp_DeletingModes.Size = new System.Drawing.Size(421, 222);
            this.tbp_DeletingModes.TabIndex = 3;
            this.tbp_DeletingModes.Text = "Deleting Modes";
            this.tbp_DeletingModes.UseVisualStyleBackColor = true;
            // 
            // tbp_TipsTricks
            // 
            this.tbp_TipsTricks.Controls.Add(this.tb_TippsTricks);
            this.tbp_TipsTricks.Location = new System.Drawing.Point(4, 22);
            this.tbp_TipsTricks.Name = "tbp_TipsTricks";
            this.tbp_TipsTricks.Size = new System.Drawing.Size(421, 222);
            this.tbp_TipsTricks.TabIndex = 4;
            this.tbp_TipsTricks.Text = "Tipps & Tricks";
            this.tbp_TipsTricks.UseVisualStyleBackColor = true;
            // 
            // tb_CreateNew
            // 
            this.tb_CreateNew.Location = new System.Drawing.Point(7, 7);
            this.tb_CreateNew.Multiline = true;
            this.tb_CreateNew.Name = "tb_CreateNew";
            this.tb_CreateNew.ReadOnly = true;
            this.tb_CreateNew.Size = new System.Drawing.Size(408, 209);
            this.tb_CreateNew.TabIndex = 2;
            this.tb_CreateNew.TabStop = false;
            this.tb_CreateNew.Text = resources.GetString("tb_CreateNew.Text");
            // 
            // tb_DeletingMode
            // 
            this.tb_DeletingMode.Location = new System.Drawing.Point(7, 7);
            this.tb_DeletingMode.Multiline = true;
            this.tb_DeletingMode.Name = "tb_DeletingMode";
            this.tb_DeletingMode.ReadOnly = true;
            this.tb_DeletingMode.Size = new System.Drawing.Size(408, 209);
            this.tb_DeletingMode.TabIndex = 2;
            this.tb_DeletingMode.TabStop = false;
            this.tb_DeletingMode.Text = resources.GetString("tb_DeletingMode.Text");
            // 
            // tb_TippsTricks
            // 
            this.tb_TippsTricks.Location = new System.Drawing.Point(7, 7);
            this.tb_TippsTricks.Multiline = true;
            this.tb_TippsTricks.Name = "tb_TippsTricks";
            this.tb_TippsTricks.ReadOnly = true;
            this.tb_TippsTricks.Size = new System.Drawing.Size(408, 209);
            this.tb_TippsTricks.TabIndex = 2;
            this.tb_TippsTricks.TabStop = false;
            this.tb_TippsTricks.Text = resources.GetString("tb_TippsTricks.Text");
            // 
            // HelpMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 302);
            this.ControlBox = false;
            this.Controls.Add(this.bt_Close);
            this.Controls.Add(this.bt_Prev);
            this.Controls.Add(this.bt_Next);
            this.Controls.Add(this.tbc_help);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelpMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Help Menu";
            this.tbc_help.ResumeLayout(false);
            this.tbp_Intro.ResumeLayout(false);
            this.tbp_Intro.PerformLayout();
            this.tbp_MapNewMode.ResumeLayout(false);
            this.tbp_MapNewMode.PerformLayout();
            this.tbp_CreateNew.ResumeLayout(false);
            this.tbp_CreateNew.PerformLayout();
            this.tbp_DeletingModes.ResumeLayout(false);
            this.tbp_DeletingModes.PerformLayout();
            this.tbp_TipsTricks.ResumeLayout(false);
            this.tbp_TipsTricks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbc_help;
        private System.Windows.Forms.TabPage tbp_Intro;
        private System.Windows.Forms.TextBox tb_Intro;
        private System.Windows.Forms.TabPage tbp_MapNewMode;
        private System.Windows.Forms.TextBox tb_MapNew;
        private System.Windows.Forms.Button bt_Next;
        private System.Windows.Forms.Button bt_Prev;
        private System.Windows.Forms.Button bt_Close;
        private System.Windows.Forms.TabPage tbp_CreateNew;
        private System.Windows.Forms.TextBox tb_CreateNew;
        private System.Windows.Forms.TabPage tbp_DeletingModes;
        private System.Windows.Forms.TabPage tbp_TipsTricks;
        private System.Windows.Forms.TextBox tb_DeletingMode;
        private System.Windows.Forms.TextBox tb_TippsTricks;
    }
}
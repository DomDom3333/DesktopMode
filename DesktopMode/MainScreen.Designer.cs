namespace DesktopMode
{
    partial class frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.bt_OpenModesLocation = new System.Windows.Forms.Button();
            this.bt_MapNew = new System.Windows.Forms.Button();
            this.bt_CreateNew = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_NewModeName = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.bt_Exit = new System.Windows.Forms.Button();
            this.bt_Help = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_OpenModesLocation
            // 
            this.bt_OpenModesLocation.Location = new System.Drawing.Point(12, 99);
            this.bt_OpenModesLocation.Name = "bt_OpenModesLocation";
            this.bt_OpenModesLocation.Size = new System.Drawing.Size(80, 39);
            this.bt_OpenModesLocation.TabIndex = 0;
            this.bt_OpenModesLocation.Text = "Open Modes Location";
            this.bt_OpenModesLocation.UseVisualStyleBackColor = true;
            this.bt_OpenModesLocation.Click += new System.EventHandler(this.bt_openModesLocation_Click);
            // 
            // bt_MapNew
            // 
            this.bt_MapNew.Location = new System.Drawing.Point(12, 13);
            this.bt_MapNew.Name = "bt_MapNew";
            this.bt_MapNew.Size = new System.Drawing.Size(80, 80);
            this.bt_MapNew.TabIndex = 1;
            this.bt_MapNew.Text = "Map New";
            this.bt_MapNew.UseVisualStyleBackColor = true;
            this.bt_MapNew.Click += new System.EventHandler(this.bt_MapNew_Click);
            // 
            // bt_CreateNew
            // 
            this.bt_CreateNew.Location = new System.Drawing.Point(98, 12);
            this.bt_CreateNew.Name = "bt_CreateNew";
            this.bt_CreateNew.Size = new System.Drawing.Size(80, 80);
            this.bt_CreateNew.TabIndex = 2;
            this.bt_CreateNew.Text = "Create New";
            this.bt_CreateNew.UseVisualStyleBackColor = true;
            this.bt_CreateNew.Click += new System.EventHandler(this.bt_CreateNew_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name for new Mode";
            // 
            // tb_NewModeName
            // 
            this.tb_NewModeName.Location = new System.Drawing.Point(297, 43);
            this.tb_NewModeName.MaxLength = 32;
            this.tb_NewModeName.Name = "tb_NewModeName";
            this.tb_NewModeName.Size = new System.Drawing.Size(155, 20);
            this.tb_NewModeName.TabIndex = 6;
            this.tb_NewModeName.Text = "New Mode Name";
            this.tb_NewModeName.TextChanged += new System.EventHandler(this.tb_NewModeName_TextChanged);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(372, 101);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(80, 39);
            this.bt_Exit.TabIndex = 8;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.UseVisualStyleBackColor = true;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_Help
            // 
            this.bt_Help.Location = new System.Drawing.Point(98, 98);
            this.bt_Help.Name = "bt_Help";
            this.bt_Help.Size = new System.Drawing.Size(80, 39);
            this.bt_Help.TabIndex = 9;
            this.bt_Help.Text = "Help";
            this.bt_Help.UseVisualStyleBackColor = true;
            this.bt_Help.Click += new System.EventHandler(this.bt_Help_Click);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 152);
            this.Controls.Add(this.bt_Help);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_NewModeName);
            this.Controls.Add(this.bt_CreateNew);
            this.Controls.Add(this.bt_MapNew);
            this.Controls.Add(this.bt_OpenModesLocation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desktop Modes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Main_FormClosing);
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_OpenModesLocation;
        private System.Windows.Forms.Button bt_MapNew;
        private System.Windows.Forms.Button bt_CreateNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_NewModeName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button bt_Exit;
        private System.Windows.Forms.Button bt_Help;
    }
}


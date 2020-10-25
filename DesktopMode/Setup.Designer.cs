namespace DesktopMode
{
    partial class Setup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup));
            this.tbc_Setup = new System.Windows.Forms.TabControl();
            this.tbp_Welcome = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbp_Save = new System.Windows.Forms.TabPage();
            this.bt_ClearSave = new System.Windows.Forms.Button();
            this.bt_BrowseSave = new System.Windows.Forms.Button();
            this.tb_SaveLocationPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbp_Backup = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_Skip = new System.Windows.Forms.CheckBox();
            this.tb_ModeName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.bt_Finish = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.bt_Prev = new System.Windows.Forms.Button();
            this.bt_Next = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.tbc_Setup.SuspendLayout();
            this.tbp_Welcome.SuspendLayout();
            this.tbp_Save.SuspendLayout();
            this.tbp_Backup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbc_Setup
            // 
            this.tbc_Setup.Controls.Add(this.tbp_Welcome);
            this.tbc_Setup.Controls.Add(this.tbp_Save);
            this.tbc_Setup.Controls.Add(this.tbp_Backup);
            this.tbc_Setup.Location = new System.Drawing.Point(12, 13);
            this.tbc_Setup.Name = "tbc_Setup";
            this.tbc_Setup.SelectedIndex = 0;
            this.tbc_Setup.Size = new System.Drawing.Size(458, 282);
            this.tbc_Setup.TabIndex = 0;
            // 
            // tbp_Welcome
            // 
            this.tbp_Welcome.Controls.Add(this.textBox1);
            this.tbp_Welcome.Controls.Add(this.label1);
            this.tbp_Welcome.Location = new System.Drawing.Point(4, 22);
            this.tbp_Welcome.Name = "tbp_Welcome";
            this.tbp_Welcome.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_Welcome.Size = new System.Drawing.Size(450, 256);
            this.tbp_Welcome.TabIndex = 0;
            this.tbp_Welcome.Text = "Welcome";
            this.tbp_Welcome.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 70);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(437, 162);
            this.textBox1.TabIndex = 1;
            this.textBox1.TabStop = false;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Desktop Modes!!";
            // 
            // tbp_Save
            // 
            this.tbp_Save.Controls.Add(this.label10);
            this.tbp_Save.Controls.Add(this.bt_ClearSave);
            this.tbp_Save.Controls.Add(this.bt_BrowseSave);
            this.tbp_Save.Controls.Add(this.tb_SaveLocationPath);
            this.tbp_Save.Controls.Add(this.label3);
            this.tbp_Save.Controls.Add(this.label2);
            this.tbp_Save.Location = new System.Drawing.Point(4, 22);
            this.tbp_Save.Name = "tbp_Save";
            this.tbp_Save.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_Save.Size = new System.Drawing.Size(450, 256);
            this.tbp_Save.TabIndex = 1;
            this.tbp_Save.Text = "Save Location";
            this.tbp_Save.UseVisualStyleBackColor = true;
            // 
            // bt_ClearSave
            // 
            this.bt_ClearSave.Location = new System.Drawing.Point(87, 124);
            this.bt_ClearSave.Name = "bt_ClearSave";
            this.bt_ClearSave.Size = new System.Drawing.Size(75, 23);
            this.bt_ClearSave.TabIndex = 6;
            this.bt_ClearSave.Text = "Clear";
            this.bt_ClearSave.UseVisualStyleBackColor = true;
            this.bt_ClearSave.Click += new System.EventHandler(this.bt_ClearSave_Click);
            // 
            // bt_BrowseSave
            // 
            this.bt_BrowseSave.Location = new System.Drawing.Point(6, 124);
            this.bt_BrowseSave.Name = "bt_BrowseSave";
            this.bt_BrowseSave.Size = new System.Drawing.Size(75, 23);
            this.bt_BrowseSave.TabIndex = 5;
            this.bt_BrowseSave.Text = "Browse";
            this.bt_BrowseSave.UseVisualStyleBackColor = true;
            this.bt_BrowseSave.Click += new System.EventHandler(this.bt_BrowseSave_Click);
            // 
            // tb_SaveLocationPath
            // 
            this.tb_SaveLocationPath.Location = new System.Drawing.Point(6, 97);
            this.tb_SaveLocationPath.Name = "tb_SaveLocationPath";
            this.tb_SaveLocationPath.Size = new System.Drawing.Size(434, 20);
            this.tb_SaveLocationPath.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Where do you want to keep your Modes saved?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lets start simple!";
            // 
            // tbp_Backup
            // 
            this.tbp_Backup.Controls.Add(this.label9);
            this.tbp_Backup.Controls.Add(this.cb_Skip);
            this.tbp_Backup.Controls.Add(this.tb_ModeName);
            this.tbp_Backup.Controls.Add(this.label8);
            this.tbp_Backup.Controls.Add(this.label7);
            this.tbp_Backup.Controls.Add(this.label5);
            this.tbp_Backup.Location = new System.Drawing.Point(4, 22);
            this.tbp_Backup.Name = "tbp_Backup";
            this.tbp_Backup.Size = new System.Drawing.Size(450, 256);
            this.tbp_Backup.TabIndex = 2;
            this.tbp_Backup.Text = "Backup";
            this.tbp_Backup.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(77, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(289, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "CREATING A BACKUP IS STRONGLY RECCOMENDED!!!";
            // 
            // cb_Skip
            // 
            this.cb_Skip.AutoSize = true;
            this.cb_Skip.Location = new System.Drawing.Point(277, 82);
            this.cb_Skip.Name = "cb_Skip";
            this.cb_Skip.Size = new System.Drawing.Size(53, 17);
            this.cb_Skip.TabIndex = 5;
            this.cb_Skip.Text = "Skip?";
            this.cb_Skip.UseVisualStyleBackColor = true;
            this.cb_Skip.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tb_ModeName
            // 
            this.tb_ModeName.Location = new System.Drawing.Point(6, 82);
            this.tb_ModeName.MaxLength = 32;
            this.tb_ModeName.Name = "tb_ModeName";
            this.tb_ModeName.Size = new System.Drawing.Size(177, 20);
            this.tb_ModeName.TabIndex = 3;
            this.tb_ModeName.Text = "Backup Mode";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(371, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "We will use your current Desktop. It will be a Backup, in case thigs go wrong.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "What do you want to call this Folder?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Lets Create a Backup!!";
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Location = new System.Drawing.Point(16, 301);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_Cancel.TabIndex = 1;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // bt_Finish
            // 
            this.bt_Finish.Location = new System.Drawing.Point(388, 301);
            this.bt_Finish.Name = "bt_Finish";
            this.bt_Finish.Size = new System.Drawing.Size(75, 23);
            this.bt_Finish.TabIndex = 2;
            this.bt_Finish.Text = "Finish";
            this.bt_Finish.UseVisualStyleBackColor = true;
            this.bt_Finish.Click += new System.EventHandler(this.bt_Finish_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "To continiue, press Next...";
            // 
            // bt_Prev
            // 
            this.bt_Prev.Enabled = false;
            this.bt_Prev.Location = new System.Drawing.Point(97, 301);
            this.bt_Prev.Name = "bt_Prev";
            this.bt_Prev.Size = new System.Drawing.Size(75, 23);
            this.bt_Prev.TabIndex = 10;
            this.bt_Prev.Text = "Back";
            this.bt_Prev.UseVisualStyleBackColor = true;
            this.bt_Prev.Click += new System.EventHandler(this.bt_Prev_Click);
            // 
            // bt_Next
            // 
            this.bt_Next.Location = new System.Drawing.Point(307, 301);
            this.bt_Next.Name = "bt_Next";
            this.bt_Next.Size = new System.Drawing.Size(75, 23);
            this.bt_Next.TabIndex = 0;
            this.bt_Next.Text = "Next";
            this.bt_Next.UseVisualStyleBackColor = true;
            this.bt_Next.Click += new System.EventHandler(this.bt_Next_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(168, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(218, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "The folder you choose needs to be EMPTY!!";
            // 
            // Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 337);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bt_Finish);
            this.Controls.Add(this.bt_Prev);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.bt_Next);
            this.Controls.Add(this.tbc_Setup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Setup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setup";
            this.tbc_Setup.ResumeLayout(false);
            this.tbp_Welcome.ResumeLayout(false);
            this.tbp_Welcome.PerformLayout();
            this.tbp_Save.ResumeLayout(false);
            this.tbp_Save.PerformLayout();
            this.tbp_Backup.ResumeLayout(false);
            this.tbp_Backup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbc_Setup;
        private System.Windows.Forms.TabPage tbp_Welcome;
        private System.Windows.Forms.TabPage tbp_Save;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Button bt_Finish;
        private System.Windows.Forms.Button bt_ClearSave;
        private System.Windows.Forms.Button bt_BrowseSave;
        private System.Windows.Forms.TextBox tb_SaveLocationPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tbp_Backup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bt_Prev;
        private System.Windows.Forms.Button bt_Next;
        private System.Windows.Forms.TextBox tb_ModeName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cb_Skip;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}
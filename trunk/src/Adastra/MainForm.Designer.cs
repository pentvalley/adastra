﻿namespace Adastra
{
    partial class MainForm
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVibesHomepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxOpenVibeWorkingFolder = new System.Windows.Forms.TextBox();
            this.textBoxScenario = new System.Windows.Forms.TextBox();
            this.buttonSelectOpenVibeWorkingFolder = new System.Windows.Forms.Button();
            this.buttonSelectScenario = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.comboBoxScenarioType = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(302, 110);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(209, 34);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Scenario type:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(798, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.homepageToolStripMenuItem,
            this.openVibesHomepageToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // homepageToolStripMenuItem
            // 
            this.homepageToolStripMenuItem.Name = "homepageToolStripMenuItem";
            this.homepageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.homepageToolStripMenuItem.Text = "Adastra\'s homepage";
            this.homepageToolStripMenuItem.Click += new System.EventHandler(this.homepageToolStripMenuItem_Click);
            // 
            // openVibesHomepageToolStripMenuItem
            // 
            this.openVibesHomepageToolStripMenuItem.Name = "openVibesHomepageToolStripMenuItem";
            this.openVibesHomepageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openVibesHomepageToolStripMenuItem.Text = "OpenVibe\'s homepage";
            this.openVibesHomepageToolStripMenuItem.Click += new System.EventHandler(this.openVibesHomepageToolStripMenuItem_Click);
            // 
            // textBoxOpenVibeWorkingFolder
            // 
            this.textBoxOpenVibeWorkingFolder.Location = new System.Drawing.Point(142, 186);
            this.textBoxOpenVibeWorkingFolder.Name = "textBoxOpenVibeWorkingFolder";
            this.textBoxOpenVibeWorkingFolder.Size = new System.Drawing.Size(179, 20);
            this.textBoxOpenVibeWorkingFolder.TabIndex = 4;
            this.textBoxOpenVibeWorkingFolder.Text = "D:\\e\\openvibe_src\\dist\\";
            // 
            // textBoxScenario
            // 
            this.textBoxScenario.Location = new System.Drawing.Point(169, 74);
            this.textBoxScenario.Name = "textBoxScenario";
            this.textBoxScenario.Size = new System.Drawing.Size(536, 20);
            this.textBoxScenario.TabIndex = 5;
            this.textBoxScenario.Text = "C:\\Users\\toncho\\Desktop\\Adastra\\scenarios\\signal-processing-VRPN-export.xml";
            // 
            // buttonSelectOpenVibeWorkingFolder
            // 
            this.buttonSelectOpenVibeWorkingFolder.Location = new System.Drawing.Point(327, 186);
            this.buttonSelectOpenVibeWorkingFolder.Name = "buttonSelectOpenVibeWorkingFolder";
            this.buttonSelectOpenVibeWorkingFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectOpenVibeWorkingFolder.TabIndex = 6;
            this.buttonSelectOpenVibeWorkingFolder.Text = "Open";
            this.buttonSelectOpenVibeWorkingFolder.UseVisualStyleBackColor = true;
            this.buttonSelectOpenVibeWorkingFolder.Click += new System.EventHandler(this.buttonSelectOpenVibeWorkingFolder_Click);
            // 
            // buttonSelectScenario
            // 
            this.buttonSelectScenario.Location = new System.Drawing.Point(711, 72);
            this.buttonSelectScenario.Name = "buttonSelectScenario";
            this.buttonSelectScenario.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectScenario.TabIndex = 7;
            this.buttonSelectScenario.Text = "Open";
            this.buttonSelectScenario.UseVisualStyleBackColor = true;
            this.buttonSelectScenario.Click += new System.EventHandler(this.buttonSelectScenario_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "OpenVibe working folder:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Scenario path:";
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(645, 169);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(141, 40);
            this.buttonExit.TabIndex = 12;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // comboBoxScenarioType
            // 
            this.comboBoxScenarioType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScenarioType.FormattingEnabled = true;
            this.comboBoxScenarioType.Items.AddRange(new object[] {
            "1. Display: multi-channel EEG from OpenVibe",
            "2. Display: LDA/SVM classification output from OpenVibe",
            "3. Train:  using OpenVibe\'s feature aggegator + Adastra\'s LDA trainer",
            "4. Train: using EEG signal +  Adastra\'s feature aggregator and LDA trainer",
            "5. Display: classes using OpenVibe\'s feature aggegator + Adastra\'s LDA classifier" +
                "",
            "6. Control: mouse cursor using OpenVibe\'s feature aggegator + Adastra\'s LDA class" +
                "ifier"});
            this.comboBoxScenarioType.Location = new System.Drawing.Point(90, 41);
            this.comboBoxScenarioType.Name = "comboBoxScenarioType";
            this.comboBoxScenarioType.Size = new System.Drawing.Size(615, 21);
            this.comboBoxScenarioType.TabIndex = 13;
            this.comboBoxScenarioType.SelectedIndexChanged += new System.EventHandler(this.comboBoxScenarioType_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 219);
            this.Controls.Add(this.comboBoxScenarioType);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSelectScenario);
            this.Controls.Add(this.buttonSelectOpenVibeWorkingFolder);
            this.Controls.Add(this.textBoxScenario);
            this.Controls.Add(this.textBoxOpenVibeWorkingFolder);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Adastra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homepageToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxOpenVibeWorkingFolder;
        private System.Windows.Forms.TextBox textBoxScenario;
        private System.Windows.Forms.Button buttonSelectOpenVibeWorkingFolder;
        private System.Windows.Forms.Button buttonSelectScenario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem openVibesHomepageToolStripMenuItem;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxScenarioType;
    }
}


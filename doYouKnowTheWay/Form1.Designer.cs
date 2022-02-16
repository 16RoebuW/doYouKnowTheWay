namespace doYouKnowTheWay
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabController = new System.Windows.Forms.TabControl();
            this.pgSettings = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSizeY = new System.Windows.Forms.TextBox();
            this.tbxSizeX = new System.Windows.Forms.TextBox();
            this.btnGenGrid = new System.Windows.Forms.Button();
            this.pgVisualisation = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnFindPath = new System.Windows.Forms.ToolStripSplitButton();
            this.btnHelp = new System.Windows.Forms.ToolStripSplitButton();
            this.tabController.SuspendLayout();
            this.pgSettings.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.Controls.Add(this.pgSettings);
            this.tabController.Controls.Add(this.pgVisualisation);
            this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabController.Location = new System.Drawing.Point(0, 0);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.Size = new System.Drawing.Size(793, 450);
            this.tabController.TabIndex = 0;
            // 
            // pgSettings
            // 
            this.pgSettings.Controls.Add(this.label2);
            this.pgSettings.Controls.Add(this.label1);
            this.pgSettings.Controls.Add(this.tbxSizeY);
            this.pgSettings.Controls.Add(this.tbxSizeX);
            this.pgSettings.Controls.Add(this.btnGenGrid);
            this.pgSettings.Location = new System.Drawing.Point(4, 22);
            this.pgSettings.Name = "pgSettings";
            this.pgSettings.Padding = new System.Windows.Forms.Padding(3);
            this.pgSettings.Size = new System.Drawing.Size(785, 424);
            this.pgSettings.TabIndex = 0;
            this.pgSettings.Text = "Settings";
            this.pgSettings.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Grid Y size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Grid X size";
            // 
            // tbxSizeY
            // 
            this.tbxSizeY.Location = new System.Drawing.Point(8, 32);
            this.tbxSizeY.Name = "tbxSizeY";
            this.tbxSizeY.Size = new System.Drawing.Size(31, 20);
            this.tbxSizeY.TabIndex = 2;
            this.tbxSizeY.Text = "10";
            // 
            // tbxSizeX
            // 
            this.tbxSizeX.Location = new System.Drawing.Point(8, 6);
            this.tbxSizeX.Name = "tbxSizeX";
            this.tbxSizeX.Size = new System.Drawing.Size(31, 20);
            this.tbxSizeX.TabIndex = 1;
            this.tbxSizeX.Text = "10";
            // 
            // btnGenGrid
            // 
            this.btnGenGrid.Location = new System.Drawing.Point(6, 58);
            this.btnGenGrid.Name = "btnGenGrid";
            this.btnGenGrid.Size = new System.Drawing.Size(95, 23);
            this.btnGenGrid.TabIndex = 0;
            this.btnGenGrid.Text = "Generate Grid";
            this.btnGenGrid.UseVisualStyleBackColor = true;
            this.btnGenGrid.Click += new System.EventHandler(this.btnGenGrid_Click);
            // 
            // pgVisualisation
            // 
            this.pgVisualisation.Location = new System.Drawing.Point(4, 22);
            this.pgVisualisation.Name = "pgVisualisation";
            this.pgVisualisation.Padding = new System.Windows.Forms.Padding(3);
            this.pgVisualisation.Size = new System.Drawing.Size(785, 424);
            this.pgVisualisation.TabIndex = 1;
            this.pgVisualisation.Text = "Visualisation";
            this.pgVisualisation.UseVisualStyleBackColor = true;
            this.pgVisualisation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pgVisualisation_MouseClick);
            this.pgVisualisation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pgVisualisation_MouseMove);
            this.pgVisualisation.Resize += new System.EventHandler(this.pgVisualisation_Resize);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.btnFindPath,
            this.btnHelp});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(793, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(222, 17);
            this.lblStatus.Text = "Choose the grid size, then press generate";
            // 
            // btnFindPath
            // 
            this.btnFindPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFindPath.Image = ((System.Drawing.Image)(resources.GetObject("btnFindPath.Image")));
            this.btnFindPath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFindPath.Name = "btnFindPath";
            this.btnFindPath.Size = new System.Drawing.Size(73, 20);
            this.btnFindPath.Text = "Find path";
            this.btnFindPath.ButtonClick += new System.EventHandler(this.btnFindPath_ButtonClick);
            // 
            // btnHelp
            // 
            this.btnHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(51, 20);
            this.btnHelp.Text = "Help!";
            this.btnHelp.ButtonClick += new System.EventHandler(this.btnHelp_ButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabController);
            this.Name = "Form1";
            this.Text = "Do you know the way?";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabController.ResumeLayout(false);
            this.pgSettings.ResumeLayout(false);
            this.pgSettings.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabController;
        private System.Windows.Forms.TabPage pgSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSizeY;
        private System.Windows.Forms.TextBox tbxSizeX;
        private System.Windows.Forms.Button btnGenGrid;
        private System.Windows.Forms.TabPage pgVisualisation;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripSplitButton btnFindPath;
        private System.Windows.Forms.ToolStripSplitButton btnHelp;
    }
}


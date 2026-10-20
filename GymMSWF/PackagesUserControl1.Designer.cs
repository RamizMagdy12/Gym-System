namespace GymMSWF
{
    partial class PackagesUserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainPanel = new Panel();
            flowPackages = new FlowLayoutPanel();
            AddPackage = new Button();
            panel1 = new Panel();
            SearchPackage = new FontAwesome.Sharp.IconButton();
            txtSearch = new TextBox();
            MainPanel.SuspendLayout();
            flowPackages.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.FromArgb(36, 48, 56);
            MainPanel.Controls.Add(flowPackages);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1086, 495);
            MainPanel.TabIndex = 3;
            // 
            // flowPackages
            // 
            flowPackages.AutoScroll = true;
            flowPackages.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPackages.Controls.Add(panel1);
            flowPackages.Controls.Add(AddPackage);
            flowPackages.Dock = DockStyle.Fill;
            flowPackages.Location = new Point(0, 0);
            flowPackages.Margin = new Padding(10);
            flowPackages.Name = "flowPackages";
            flowPackages.Size = new Size(1086, 495);
            flowPackages.TabIndex = 1;
            // 
            // AddPackage
            // 
            AddPackage.AutoSize = true;
            AddPackage.BackColor = Color.FromArgb(74, 169, 81);
            AddPackage.FlatAppearance.BorderSize = 0;
            AddPackage.FlatStyle = FlatStyle.Flat;
            AddPackage.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddPackage.ForeColor = Color.White;
            AddPackage.Location = new Point(363, 3);
            AddPackage.Name = "AddPackage";
            AddPackage.Size = new Size(166, 47);
            AddPackage.TabIndex = 4;
            AddPackage.Text = "+  Add Package";
            AddPackage.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(62, 78, 90);
            panel1.Controls.Add(SearchPackage);
            panel1.Controls.Add(txtSearch);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(354, 47);
            panel1.TabIndex = 5;
            // 
            // SearchPackage
            // 
            SearchPackage.Cursor = Cursors.Hand;
            SearchPackage.FlatAppearance.BorderSize = 0;
            SearchPackage.FlatStyle = FlatStyle.Flat;
            SearchPackage.Font = new Font("Segoe UI", 4.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchPackage.IconChar = FontAwesome.Sharp.IconChar.Search;
            SearchPackage.IconColor = Color.FromArgb(210, 212, 217);
            SearchPackage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SearchPackage.IconSize = 30;
            SearchPackage.Location = new Point(22, 7);
            SearchPackage.Name = "SearchPackage";
            SearchPackage.Size = new Size(43, 30);
            SearchPackage.TabIndex = 2;
            SearchPackage.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(47, 61, 71);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(71, 7);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(271, 34);
            txtSearch.TabIndex = 0;
            // 
            // PackagesUserControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(MainPanel);
            Name = "PackagesUserControl1";
            Size = new Size(1086, 495);
            MainPanel.ResumeLayout(false);
            flowPackages.ResumeLayout(false);
            flowPackages.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel MainPanel;
        private FlowLayoutPanel flowPackages;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton SearchPackage;
        private TextBox txtSearch;
        private Button AddPackage;
    }
}

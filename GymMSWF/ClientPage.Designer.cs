namespace GymMSWF
{
    partial class ClientPage
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            SearchTxt = new Guna.UI2.WinForms.Guna2TextBox();
            Addbtn = new Guna.UI2.WinForms.Guna2Button();
            ClientData = new Guna.UI2.WinForms.Guna2DataGridView();
            Deletebtn = new Guna.UI2.WinForms.Guna2Button();
            Updatebtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)ClientData).BeginInit();
            SuspendLayout();
            // 
            // SearchTxt
            // 
            SearchTxt.BorderColor = Color.FromArgb(74, 169, 81);
            SearchTxt.BorderRadius = 10;
            SearchTxt.CustomizableEdges = customizableEdges1;
            SearchTxt.DefaultText = "";
            SearchTxt.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            SearchTxt.DisabledState.FillColor = Color.FromArgb(50, 50, 50);
            SearchTxt.DisabledState.ForeColor = Color.Gray;
            SearchTxt.DisabledState.PlaceholderForeColor = Color.Gray;
            SearchTxt.FillColor = Color.FromArgb(47, 61, 71);
            SearchTxt.FocusedState.BorderColor = Color.FromArgb(74, 169, 81);
            SearchTxt.Font = new Font("Segoe UI", 10F);
            SearchTxt.ForeColor = Color.White;
            SearchTxt.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            SearchTxt.IconLeft = Properties.Resources.magnifying_glass;
            SearchTxt.Location = new Point(31, 30);
            SearchTxt.Margin = new Padding(3, 4, 3, 4);
            SearchTxt.Name = "SearchTxt";
            SearchTxt.PlaceholderText = "Search client...";
            SearchTxt.SelectedText = "";
            SearchTxt.ShadowDecoration.CustomizableEdges = customizableEdges2;
            SearchTxt.Size = new Size(400, 45);
            SearchTxt.TabIndex = 3;
            SearchTxt.TextChanged += SearchTxt_TextChanged;
            // 
            // Addbtn
            // 
            Addbtn.CustomizableEdges = customizableEdges3;
            Addbtn.DisabledState.BorderColor = Color.DarkGray;
            Addbtn.DisabledState.CustomBorderColor = Color.DarkGray;
            Addbtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Addbtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Addbtn.FillColor = Color.FromArgb(74, 169, 81);
            Addbtn.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Addbtn.ForeColor = Color.White;
            Addbtn.Location = new Point(932, 32);
            Addbtn.Name = "Addbtn";
            Addbtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            Addbtn.Size = new Size(164, 44);
            Addbtn.TabIndex = 2;
            Addbtn.Text = "+ Add Client";
            Addbtn.Click += Addbtn_Click;
            // 
            // ClientData
            // 
            ClientData.AllowUserToAddRows = false;
            ClientData.AllowUserToDeleteRows = false;
            ClientData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(36, 48, 56);
            dataGridViewCellStyle1.ForeColor = Color.White;
            ClientData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            ClientData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            ClientData.BackgroundColor = Color.FromArgb(36, 48, 56);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(61, 155, 150);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            ClientData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            ClientData.ColumnHeadersHeight = 40;
            ClientData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(36, 48, 56);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(74, 169, 81);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            ClientData.DefaultCellStyle = dataGridViewCellStyle3;
            ClientData.GridColor = Color.FromArgb(36, 48, 56);
            ClientData.Location = new Point(12, 126);
            ClientData.Name = "ClientData";
            ClientData.ReadOnly = true;
            ClientData.RowHeadersVisible = false;
            ClientData.RowHeadersWidth = 51;
            ClientData.RowTemplate.Height = 30;
            ClientData.Size = new Size(1218, 380);
            ClientData.TabIndex = 0;
            ClientData.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(36, 48, 56);
            ClientData.ThemeStyle.AlternatingRowsStyle.Font = null;
            ClientData.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.White;
            ClientData.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            ClientData.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            ClientData.ThemeStyle.BackColor = Color.FromArgb(36, 48, 56);
            ClientData.ThemeStyle.GridColor = Color.FromArgb(36, 48, 56);
            ClientData.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(61, 155, 150);
            ClientData.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            ClientData.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ClientData.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            ClientData.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            ClientData.ThemeStyle.HeaderStyle.Height = 40;
            ClientData.ThemeStyle.ReadOnly = true;
            ClientData.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(36, 48, 56);
            ClientData.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ClientData.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            ClientData.ThemeStyle.RowsStyle.ForeColor = Color.White;
            ClientData.ThemeStyle.RowsStyle.Height = 30;
            ClientData.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(74, 169, 81);
            ClientData.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
            // 
            // Deletebtn
            // 
            Deletebtn.CustomizableEdges = customizableEdges5;
            Deletebtn.DisabledState.BorderColor = Color.DarkGray;
            Deletebtn.DisabledState.CustomBorderColor = Color.DarkGray;
            Deletebtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Deletebtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Deletebtn.FillColor = Color.Red;
            Deletebtn.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Deletebtn.ForeColor = Color.White;
            Deletebtn.Location = new Point(592, 32);
            Deletebtn.Name = "Deletebtn";
            Deletebtn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            Deletebtn.Size = new Size(164, 44);
            Deletebtn.TabIndex = 8;
            Deletebtn.Text = "Delete";
            Deletebtn.Click += Deletebtn_Click;
            // 
            // Updatebtn
            // 
            Updatebtn.CustomizableEdges = customizableEdges7;
            Updatebtn.DisabledState.BorderColor = Color.DarkGray;
            Updatebtn.DisabledState.CustomBorderColor = Color.DarkGray;
            Updatebtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Updatebtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Updatebtn.FillColor = Color.FromArgb(61, 155, 150);
            Updatebtn.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Updatebtn.ForeColor = Color.White;
            Updatebtn.Location = new Point(762, 31);
            Updatebtn.Name = "Updatebtn";
            Updatebtn.ShadowDecoration.CustomizableEdges = customizableEdges8;
            Updatebtn.Size = new Size(164, 44);
            Updatebtn.TabIndex = 9;
            Updatebtn.Text = "Update";
            Updatebtn.Click += Updatebtn_Click;
            // 
            // ClientPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 48, 56);
            ClientSize = new Size(1242, 541);
            Controls.Add(Updatebtn);
            Controls.Add(Deletebtn);
            Controls.Add(ClientData);
            Controls.Add(Addbtn);
            Controls.Add(SearchTxt);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ClientPage";
            Text = "ClientPage";
            Load += ClientPage_Load;
            ((System.ComponentModel.ISupportInitialize)ClientData).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox SearchTxt;
        private Guna.UI2.WinForms.Guna2Button Addbtn;
        private Guna.UI2.WinForms.Guna2DataGridView ClientData;
        private Guna.UI2.WinForms.Guna2Button Deletebtn;
        private Guna.UI2.WinForms.Guna2Button Updatebtn;
    }
}

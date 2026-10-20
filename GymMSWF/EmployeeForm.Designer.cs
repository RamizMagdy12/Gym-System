namespace GymMSWF
{
	partial class EmployeeForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            EmployeeData = new Guna.UI2.WinForms.Guna2DataGridView();
            SearchTxt = new Guna.UI2.WinForms.Guna2TextBox();
            Deletebtn = new Guna.UI2.WinForms.Guna2Button();
            Updatebtn = new Guna.UI2.WinForms.Guna2Button();
            Addbtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)EmployeeData).BeginInit();
            SuspendLayout();
            // 
            // EmployeeData
            // 
            EmployeeData.AllowUserToAddRows = false;
            EmployeeData.AllowUserToDeleteRows = false;
            EmployeeData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(36, 48, 56);
            dataGridViewCellStyle1.ForeColor = Color.White;
            EmployeeData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            EmployeeData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            EmployeeData.BackgroundColor = Color.FromArgb(36, 48, 56);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(61, 155, 150);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            EmployeeData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            EmployeeData.ColumnHeadersHeight = 40;
            EmployeeData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(36, 48, 56);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(74, 169, 81);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            EmployeeData.DefaultCellStyle = dataGridViewCellStyle3;
            EmployeeData.GridColor = Color.FromArgb(36, 48, 56);
            EmployeeData.Location = new Point(21, 121);
            EmployeeData.Name = "EmployeeData";
            EmployeeData.ReadOnly = true;
            EmployeeData.RowHeadersVisible = false;
            EmployeeData.RowHeadersWidth = 51;
            EmployeeData.RowTemplate.Height = 30;
            EmployeeData.Size = new Size(1218, 380);
            EmployeeData.TabIndex = 1;
            EmployeeData.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(36, 48, 56);
            EmployeeData.ThemeStyle.AlternatingRowsStyle.Font = null;
            EmployeeData.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.White;
            EmployeeData.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            EmployeeData.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            EmployeeData.ThemeStyle.BackColor = Color.FromArgb(36, 48, 56);
            EmployeeData.ThemeStyle.GridColor = Color.FromArgb(36, 48, 56);
            EmployeeData.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(61, 155, 150);
            EmployeeData.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            EmployeeData.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            EmployeeData.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            EmployeeData.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            EmployeeData.ThemeStyle.HeaderStyle.Height = 40;
            EmployeeData.ThemeStyle.ReadOnly = true;
            EmployeeData.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(36, 48, 56);
            EmployeeData.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            EmployeeData.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            EmployeeData.ThemeStyle.RowsStyle.ForeColor = Color.White;
            EmployeeData.ThemeStyle.RowsStyle.Height = 30;
            EmployeeData.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(74, 169, 81);
            EmployeeData.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
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
            SearchTxt.Location = new Point(12, 23);
            SearchTxt.Margin = new Padding(3, 4, 3, 4);
            SearchTxt.Name = "SearchTxt";
            SearchTxt.PlaceholderText = "Search employee...";
            SearchTxt.SelectedText = "";
            SearchTxt.ShadowDecoration.CustomizableEdges = customizableEdges2;
            SearchTxt.Size = new Size(400, 45);
            SearchTxt.TabIndex = 4;
			SearchTxt.TextChanged += SearchTxt_TextChanged;
			// 
			// Deletebtn
			// 
			Deletebtn.CustomizableEdges = customizableEdges3;
            Deletebtn.DisabledState.BorderColor = Color.DarkGray;
            Deletebtn.DisabledState.CustomBorderColor = Color.DarkGray;
            Deletebtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Deletebtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Deletebtn.FillColor = Color.Red;
            Deletebtn.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Deletebtn.ForeColor = Color.White;
            Deletebtn.Location = new Point(553, 23);
            Deletebtn.Name = "Deletebtn";
            Deletebtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            Deletebtn.Size = new Size(164, 44);
            Deletebtn.TabIndex = 9;
            Deletebtn.Text = "Delete";
            Deletebtn.Click += Deletebtn_Click;
            // 
            // Updatebtn
            // 
            Updatebtn.CustomizableEdges = customizableEdges5;
            Updatebtn.DisabledState.BorderColor = Color.DarkGray;
            Updatebtn.DisabledState.CustomBorderColor = Color.DarkGray;
            Updatebtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Updatebtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Updatebtn.FillColor = Color.FromArgb(61, 155, 150);
            Updatebtn.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Updatebtn.ForeColor = Color.White;
            Updatebtn.Location = new Point(723, 23);
            Updatebtn.Name = "Updatebtn";
            Updatebtn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            Updatebtn.Size = new Size(164, 44);
            Updatebtn.TabIndex = 10;
            Updatebtn.Text = "Update";
            Updatebtn.Click += Updatebtn_Click;
            // 
            // Addbtn
            // 
            Addbtn.CustomizableEdges = customizableEdges7;
            Addbtn.DisabledState.BorderColor = Color.DarkGray;
            Addbtn.DisabledState.CustomBorderColor = Color.DarkGray;
            Addbtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Addbtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Addbtn.FillColor = Color.FromArgb(74, 169, 81);
            Addbtn.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Addbtn.ForeColor = Color.White;
            Addbtn.Location = new Point(893, 23);
            Addbtn.Name = "Addbtn";
            Addbtn.ShadowDecoration.CustomizableEdges = customizableEdges8;
            Addbtn.Size = new Size(164, 44);
            Addbtn.TabIndex = 11;
            Addbtn.Text = "+ Add Employee";
            Addbtn.Click += Addbtn_Click;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 48, 56);
            ClientSize = new Size(1260, 513);
            Controls.Add(Addbtn);
            Controls.Add(Updatebtn);
            Controls.Add(Deletebtn);
            Controls.Add(SearchTxt);
            Controls.Add(EmployeeData);
            Name = "EmployeeForm";
            Text = "EmployeeForm";
            Load += EmployeeForm_Load;
            ((System.ComponentModel.ISupportInitialize)EmployeeData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView EmployeeData;
		private Guna.UI2.WinForms.Guna2TextBox SearchTxt;
		private Guna.UI2.WinForms.Guna2Button Deletebtn;
		private Guna.UI2.WinForms.Guna2Button Updatebtn;
		private Guna.UI2.WinForms.Guna2Button Addbtn;
	}
}
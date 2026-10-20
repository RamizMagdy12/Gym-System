namespace GymMSWF
{
    partial class PaymentForm
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
            paymentData = new Guna.UI2.WinForms.Guna2DataGridView();
            SearchTxt = new Guna.UI2.WinForms.Guna2TextBox();
            Addbtn = new Guna.UI2.WinForms.Guna2Button();
            Updatebtn = new Guna.UI2.WinForms.Guna2Button();
            Deletebtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)paymentData).BeginInit();
            SuspendLayout();

            // 
            // paymentData
            // 
            paymentData.AllowUserToAddRows = false;
            paymentData.AllowUserToDeleteRows = false;
            paymentData.AllowUserToResizeRows = false;

            dataGridViewCellStyle1.BackColor = Color.FromArgb(36, 48, 56);
            dataGridViewCellStyle1.ForeColor = Color.White;
            paymentData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;

            paymentData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            paymentData.BackgroundColor = Color.FromArgb(36, 48, 56);

            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(61, 155, 150);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            paymentData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            paymentData.ColumnHeadersHeight = 28;
            paymentData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(36, 48, 56);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(74, 169, 81);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            paymentData.DefaultCellStyle = dataGridViewCellStyle3;

            paymentData.GridColor = Color.FromArgb(36, 48, 56);
            paymentData.Location = new Point(38, 82);
            paymentData.Name = "paymentData";
            paymentData.ReadOnly = true;
            paymentData.RowHeadersVisible = false;
            paymentData.RowTemplate.Height = 30;
            paymentData.Size = new Size(1181, 380);
            paymentData.TabIndex = 1;

            paymentData.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(36, 48, 56);
            paymentData.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.White;
            paymentData.ThemeStyle.BackColor = Color.FromArgb(36, 48, 56);
            paymentData.ThemeStyle.GridColor = Color.FromArgb(36, 48, 56);
            paymentData.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(61, 155, 150);
            paymentData.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            paymentData.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            paymentData.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            paymentData.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            paymentData.ThemeStyle.HeaderStyle.Height = 28;
            paymentData.ThemeStyle.ReadOnly = true;
            paymentData.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(36, 48, 56);
            paymentData.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            paymentData.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            paymentData.ThemeStyle.RowsStyle.ForeColor = Color.White;
            paymentData.ThemeStyle.RowsStyle.Height = 30;
            paymentData.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(74, 169, 81);
            paymentData.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;

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
            SearchTxt.Location = new Point(21, 13);
            SearchTxt.Margin = new Padding(3, 4, 3, 4);
            SearchTxt.Name = "SearchTxt";
            SearchTxt.PlaceholderText = "Search client...";
            SearchTxt.SelectedText = "";
            SearchTxt.ShadowDecoration.CustomizableEdges = customizableEdges2;
            SearchTxt.Size = new Size(400, 45);
            SearchTxt.TabIndex = 4;
            SearchTxt.TextChanged += SearchTxt_TextChanged;

            // 
            // Addbtn
            // 
            Addbtn.CustomizableEdges = customizableEdges3;
            Addbtn.FillColor = Color.FromArgb(74, 169, 81);
            Addbtn.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            Addbtn.ForeColor = Color.White;
            Addbtn.Location = new Point(911, 12);
            Addbtn.Name = "Addbtn";
            Addbtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            Addbtn.Size = new Size(164, 44);
            Addbtn.TabIndex = 5;
            Addbtn.Text = "+ Add Payment";
            Addbtn.Click += Addbtn_Click;

            // 
            // Updatebtn
            // 
            Updatebtn.CustomizableEdges = customizableEdges5;
            Updatebtn.FillColor = Color.FromArgb(61, 155, 150);
            Updatebtn.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            Updatebtn.ForeColor = Color.White;
            Updatebtn.Location = new Point(741, 12);
            Updatebtn.Name = "Updatebtn";
            Updatebtn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            Updatebtn.Size = new Size(164, 44);
            Updatebtn.TabIndex = 6;
            Updatebtn.Text = "Update";
            Updatebtn.Click += Updatebtn_Click;

            // 
            // Deletebtn
            // 
            Deletebtn.CustomizableEdges = customizableEdges7;
            Deletebtn.FillColor = Color.Red;
            Deletebtn.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            Deletebtn.ForeColor = Color.White;
            Deletebtn.Location = new Point(571, 12);
            Deletebtn.Name = "Deletebtn";
            Deletebtn.ShadowDecoration.CustomizableEdges = customizableEdges8;
            Deletebtn.Size = new Size(164, 44);
            Deletebtn.TabIndex = 7;
            Deletebtn.Text = "Delete";
            Deletebtn.Click += Deletebtn_Click;

            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 48, 56);
            ClientSize = new Size(1295, 545);
            Controls.Add(Deletebtn);
            Controls.Add(Updatebtn);
            Controls.Add(Addbtn);
            Controls.Add(SearchTxt);
            Controls.Add(paymentData);
            Name = "PaymentForm";
            Text = "Payment";
            Load += Payment_Load;
            ((System.ComponentModel.ISupportInitialize)paymentData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView paymentData;
        private Guna.UI2.WinForms.Guna2TextBox SearchTxt;
        private Guna.UI2.WinForms.Guna2Button Addbtn;
        private Guna.UI2.WinForms.Guna2Button Updatebtn;
        private Guna.UI2.WinForms.Guna2Button Deletebtn;
    }
}

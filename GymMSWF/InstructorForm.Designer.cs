namespace GymMSWF
{
    partial class InstructorForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            flowLayoutPanel1 = new FlowLayoutPanel();
            AddInstructorBTN = new Guna.UI2.WinForms.Guna2Button();
            searchTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            searchIconButton = new FontAwesome.Sharp.IconButton();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.FromArgb(36, 48, 56);
            flowLayoutPanel1.Location = new Point(35, 103);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Size = new Size(1225, 676);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // AddInstructorBTN
            // 
            AddInstructorBTN.CustomizableEdges = customizableEdges1;
            AddInstructorBTN.DisabledState.BorderColor = Color.DarkGray;
            AddInstructorBTN.DisabledState.CustomBorderColor = Color.DarkGray;
            AddInstructorBTN.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            AddInstructorBTN.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            AddInstructorBTN.FillColor = Color.FromArgb(74, 169, 81);
            AddInstructorBTN.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddInstructorBTN.ForeColor = Color.White;
            AddInstructorBTN.Location = new Point(1019, 20);
            AddInstructorBTN.Name = "AddInstructorBTN";
            AddInstructorBTN.ShadowDecoration.CustomizableEdges = customizableEdges2;
            AddInstructorBTN.Size = new Size(183, 52);
            AddInstructorBTN.TabIndex = 2;
            AddInstructorBTN.Text = "+ Add Instructor";
            AddInstructorBTN.Click += AddInstructorBTN_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.BackColor = Color.FromArgb(47, 61, 71);
            searchTextBox.BorderColor = Color.FromArgb(47, 61, 71);
            searchTextBox.CustomizableEdges = customizableEdges3;
            searchTextBox.DefaultText = "";
            searchTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            searchTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            searchTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            searchTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            searchTextBox.FillColor = Color.FromArgb(47, 61, 71);
            searchTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            searchTextBox.Font = new Font("Segoe UI", 9F);
            searchTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            searchTextBox.Location = new Point(45, 4);
            searchTextBox.Margin = new Padding(3, 4, 3, 4);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "";
            searchTextBox.SelectedText = "";
            searchTextBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            searchTextBox.Size = new Size(250, 35);
            searchTextBox.TabIndex = 3;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.FromArgb(62, 78, 90);
            guna2Panel1.Controls.Add(searchIconButton);
            guna2Panel1.Controls.Add(searchTextBox);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Location = new Point(35, 16);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(298, 45);
            guna2Panel1.TabIndex = 4;
            // 
            // searchIconButton
            // 
            searchIconButton.FlatAppearance.BorderSize = 0;
            searchIconButton.FlatStyle = FlatStyle.Flat;
            searchIconButton.IconChar = FontAwesome.Sharp.IconChar.Search;
            searchIconButton.IconColor = Color.Black;
            searchIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            searchIconButton.IconSize = 30;
            searchIconButton.Location = new Point(0, 4);
            searchIconButton.Name = "searchIconButton";
            searchIconButton.Size = new Size(53, 35);
            searchIconButton.TabIndex = 5;
            searchIconButton.UseVisualStyleBackColor = true;
            searchIconButton.Click += searchIconButton_Click;
            // 
            // InstructorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 48, 56);
            ClientSize = new Size(1287, 791);
            Controls.Add(guna2Panel1);
            Controls.Add(AddInstructorBTN);
            Controls.Add(flowLayoutPanel1);
            Name = "InstructorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InstructorForm";
            Load += InstructorForm_Load;
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button AddInstructorBTN;
        private Guna.UI2.WinForms.Guna2TextBox searchTextBox;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private FontAwesome.Sharp.IconButton searchIconButton;
    }
}

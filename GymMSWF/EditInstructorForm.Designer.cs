namespace GymMSWF
{
    partial class EditInstructorForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            chooseImgeBtn = new Guna.UI2.WinForms.Guna2Button();
            PictureBox = new Guna.UI2.WinForms.Guna2PictureBox();
            DateTimePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            editInsbutton = new Button();
            maleRadioButton = new RadioButton();
            femaleRadioButton = new RadioButton();
            LNametextBox = new TextBox();
            EmailtextBox = new TextBox();
            phonetextBox = new TextBox();
            titletextBox = new TextBox();
            salarytextBox = new TextBox();
            FNametextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            SuspendLayout();
            // 
            // chooseImgeBtn
            // 
            chooseImgeBtn.CustomizableEdges = customizableEdges1;
            chooseImgeBtn.DisabledState.BorderColor = Color.DarkGray;
            chooseImgeBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            chooseImgeBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            chooseImgeBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            chooseImgeBtn.FillColor = Color.FromArgb(61, 155, 150);
            chooseImgeBtn.Font = new Font("Segoe UI", 9F);
            chooseImgeBtn.ForeColor = Color.White;
            chooseImgeBtn.Location = new Point(118, 92);
            chooseImgeBtn.Name = "chooseImgeBtn";
            chooseImgeBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            chooseImgeBtn.Size = new Size(41, 27);
            chooseImgeBtn.TabIndex = 45;
            chooseImgeBtn.Text = "...";
            chooseImgeBtn.Click += chooseImgeBtn_Click;
            // 
            // PictureBox
            // 
            PictureBox.CustomizableEdges = customizableEdges3;
            PictureBox.FillColor = Color.FromArgb(47, 61, 71);
            PictureBox.ImageRotate = 0F;
            PictureBox.Location = new Point(6, 23);
            PictureBox.Name = "PictureBox";
            PictureBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            PictureBox.Size = new Size(106, 96);
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.TabIndex = 44;
            PictureBox.TabStop = false;
            // 
            // DateTimePicker
            // 
            DateTimePicker.Checked = true;
            DateTimePicker.CustomizableEdges = customizableEdges5;
            DateTimePicker.FillColor = Color.FromArgb(47, 61, 71);
            DateTimePicker.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DateTimePicker.Format = DateTimePickerFormat.Long;
            DateTimePicker.Location = new Point(3, 168);
            DateTimePicker.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            DateTimePicker.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            DateTimePicker.Name = "DateTimePicker";
            DateTimePicker.ShadowDecoration.CustomizableEdges = customizableEdges6;
            DateTimePicker.Size = new Size(227, 27);
            DateTimePicker.TabIndex = 43;
            DateTimePicker.Value = new DateTime(2025, 10, 14, 0, 36, 30, 581);
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(260, 282);
            label9.Name = "label9";
            label9.Size = new Size(56, 19);
            label9.TabIndex = 42;
            label9.Text = "Salary";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(3, 282);
            label8.Name = "label8";
            label8.Size = new Size(45, 19);
            label8.TabIndex = 41;
            label8.Text = "Title";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(3, 198);
            label7.Name = "label7";
            label7.Size = new Size(54, 19);
            label7.TabIndex = 40;
            label7.Text = "Email";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(260, 198);
            label6.Name = "label6";
            label6.Size = new Size(55, 19);
            label6.TabIndex = 39;
            label6.Text = "Phone";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(251, 136);
            label5.Name = "label5";
            label5.Size = new Size(65, 19);
            label5.TabIndex = 38;
            label5.Text = "Gender";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 136);
            label4.Name = "label4";
            label4.Size = new Size(106, 19);
            label4.TabIndex = 37;
            label4.Text = "Date of Birth";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(179, 69);
            label3.Name = "label3";
            label3.Size = new Size(87, 19);
            label3.TabIndex = 36;
            label3.Text = "Last Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(179, 2);
            label2.Name = "label2";
            label2.Size = new Size(93, 19);
            label2.TabIndex = 35;
            label2.Text = "First Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 1);
            label1.Name = "label1";
            label1.Size = new Size(54, 19);
            label1.TabIndex = 34;
            label1.Text = "Image";
            // 
            // editInsbutton
            // 
            editInsbutton.BackColor = Color.FromArgb(61, 155, 150);
            editInsbutton.FlatAppearance.BorderSize = 0;
            editInsbutton.FlatStyle = FlatStyle.Flat;
            editInsbutton.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editInsbutton.ForeColor = Color.White;
            editInsbutton.Location = new Point(12, 459);
            editInsbutton.Name = "editInsbutton";
            editInsbutton.Size = new Size(443, 29);
            editInsbutton.TabIndex = 33;
            editInsbutton.Text = "Edit";
            editInsbutton.UseVisualStyleBackColor = false;
            editInsbutton.Click += editInsbutton_Click;
            // 
            // maleRadioButton
            // 
            maleRadioButton.AutoSize = true;
            maleRadioButton.Font = new Font("Times New Roman", 10.2F);
            maleRadioButton.ForeColor = Color.White;
            maleRadioButton.Location = new Point(368, 158);
            maleRadioButton.Name = "maleRadioButton";
            maleRadioButton.Size = new Size(65, 23);
            maleRadioButton.TabIndex = 32;
            maleRadioButton.Text = "Male";
            maleRadioButton.UseVisualStyleBackColor = true;
            // 
            // femaleRadioButton
            // 
            femaleRadioButton.AutoSize = true;
            femaleRadioButton.Checked = true;
            femaleRadioButton.Font = new Font("Times New Roman", 10.2F);
            femaleRadioButton.ForeColor = SystemColors.Window;
            femaleRadioButton.Location = new Point(260, 158);
            femaleRadioButton.Name = "femaleRadioButton";
            femaleRadioButton.Size = new Size(80, 23);
            femaleRadioButton.TabIndex = 31;
            femaleRadioButton.TabStop = true;
            femaleRadioButton.Text = "Female";
            femaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // LNametextBox
            // 
            LNametextBox.BackColor = Color.FromArgb(47, 61, 71);
            LNametextBox.BorderStyle = BorderStyle.FixedSingle;
            LNametextBox.ForeColor = Color.White;
            LNametextBox.Location = new Point(179, 92);
            LNametextBox.Name = "LNametextBox";
            LNametextBox.Size = new Size(254, 27);
            LNametextBox.TabIndex = 30;
            // 
            // EmailtextBox
            // 
            EmailtextBox.BackColor = Color.FromArgb(47, 61, 71);
            EmailtextBox.BorderStyle = BorderStyle.FixedSingle;
            EmailtextBox.ForeColor = Color.White;
            EmailtextBox.Location = new Point(5, 230);
            EmailtextBox.Name = "EmailtextBox";
            EmailtextBox.Size = new Size(227, 27);
            EmailtextBox.TabIndex = 29;
            // 
            // phonetextBox
            // 
            phonetextBox.BackColor = Color.FromArgb(47, 61, 71);
            phonetextBox.BorderStyle = BorderStyle.FixedSingle;
            phonetextBox.ForeColor = Color.White;
            phonetextBox.Location = new Point(260, 230);
            phonetextBox.Name = "phonetextBox";
            phonetextBox.Size = new Size(195, 27);
            phonetextBox.TabIndex = 28;
            // 
            // titletextBox
            // 
            titletextBox.BackColor = Color.FromArgb(47, 61, 71);
            titletextBox.BorderStyle = BorderStyle.FixedSingle;
            titletextBox.ForeColor = Color.White;
            titletextBox.Location = new Point(3, 312);
            titletextBox.Name = "titletextBox";
            titletextBox.Size = new Size(227, 27);
            titletextBox.TabIndex = 27;
            // 
            // salarytextBox
            // 
            salarytextBox.BackColor = Color.FromArgb(47, 61, 71);
            salarytextBox.BorderStyle = BorderStyle.FixedSingle;
            salarytextBox.ForeColor = Color.White;
            salarytextBox.Location = new Point(260, 312);
            salarytextBox.Name = "salarytextBox";
            salarytextBox.Size = new Size(195, 27);
            salarytextBox.TabIndex = 26;
            // 
            // FNametextBox
            // 
            FNametextBox.BackColor = Color.FromArgb(47, 61, 71);
            FNametextBox.BorderStyle = BorderStyle.FixedSingle;
            FNametextBox.ForeColor = Color.White;
            FNametextBox.Location = new Point(179, 25);
            FNametextBox.Name = "FNametextBox";
            FNametextBox.Size = new Size(254, 27);
            FNametextBox.TabIndex = 25;
            // 
            // EditInstructorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(62, 78, 90);
            ClientSize = new Size(474, 510);
            Controls.Add(chooseImgeBtn);
            Controls.Add(PictureBox);
            Controls.Add(DateTimePicker);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(editInsbutton);
            Controls.Add(maleRadioButton);
            Controls.Add(femaleRadioButton);
            Controls.Add(LNametextBox);
            Controls.Add(EmailtextBox);
            Controls.Add(phonetextBox);
            Controls.Add(titletextBox);
            Controls.Add(salarytextBox);
            Controls.Add(FNametextBox);
            Name = "EditInstructorForm";
            Text = "EditInstructorForm";
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button chooseImgeBtn;
        private Guna.UI2.WinForms.Guna2PictureBox PictureBox;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateTimePicker;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button editInsbutton;
        private RadioButton maleRadioButton;
        private RadioButton femaleRadioButton;
        private TextBox LNametextBox;
        private TextBox EmailtextBox;
        private TextBox phonetextBox;
        private TextBox titletextBox;
        private TextBox salarytextBox;
        private TextBox FNametextBox;
    }
}
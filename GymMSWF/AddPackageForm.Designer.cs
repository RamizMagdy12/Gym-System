namespace GymMSWF
{
    partial class AddPackageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPackageForm));
            label1 = new Label();
            txtTitle = new TextBox();
            label2 = new Label();
            PictureAddPack = new PictureBox();
            AddImage = new Button();
            SaveNewPackage = new Button();
            label3 = new Label();
            label4 = new Label();
            txtcountSession = new TextBox();
            txtPrice = new TextBox();
            label5 = new Label();
            label6 = new Label();
            txtDescription = new TextBox();
            comboInstructors = new ComboBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)PictureAddPack).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.2F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(37, 106);
            label1.Name = "label1";
            label1.Size = new Size(40, 19);
            label1.TabIndex = 0;
            label1.Text = "Title";
            // 
            // txtTitle
            // 
            txtTitle.BackColor = Color.FromArgb(47, 61, 71);
            txtTitle.BorderStyle = BorderStyle.None;
            txtTitle.ForeColor = Color.White;
            txtTitle.Location = new Point(37, 139);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(518, 27);
            txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.2F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(37, 191);
            label2.Name = "label2";
            label2.Size = new Size(50, 19);
            label2.TabIndex = 2;
            label2.Text = "Image";
            // 
            // PictureAddPack
            // 
            PictureAddPack.BorderStyle = BorderStyle.FixedSingle;
            PictureAddPack.Location = new Point(37, 214);
            PictureAddPack.Name = "PictureAddPack";
            PictureAddPack.Size = new Size(142, 153);
            PictureAddPack.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureAddPack.TabIndex = 3;
            PictureAddPack.TabStop = false;
            // 
            // AddImage
            // 
            AddImage.BackColor = Color.FromArgb(61, 155, 150);
            AddImage.FlatAppearance.BorderSize = 0;
            AddImage.FlatStyle = FlatStyle.Flat;
            AddImage.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddImage.ForeColor = Color.White;
            AddImage.Location = new Point(185, 332);
            AddImage.Name = "AddImage";
            AddImage.Size = new Size(40, 35);
            AddImage.TabIndex = 4;
            AddImage.Text = "...";
            AddImage.UseVisualStyleBackColor = false;
            AddImage.Click += AddImage_Click;
            // 
            // SaveNewPackage
            // 
            SaveNewPackage.BackColor = Color.FromArgb(61, 155, 150);
            SaveNewPackage.FlatAppearance.BorderSize = 0;
            SaveNewPackage.FlatStyle = FlatStyle.Flat;
            SaveNewPackage.Font = new Font("Times New Roman", 10.2F);
            SaveNewPackage.ForeColor = Color.White;
            SaveNewPackage.Location = new Point(37, 582);
            SaveNewPackage.Name = "SaveNewPackage";
            SaveNewPackage.Size = new Size(518, 37);
            SaveNewPackage.TabIndex = 5;
            SaveNewPackage.Text = "Save";
            SaveNewPackage.UseVisualStyleBackColor = false;
            SaveNewPackage.Click += SaveNewPackage_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10.2F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(37, 442);
            label3.Name = "label3";
            label3.Size = new Size(90, 19);
            label3.TabIndex = 7;
            label3.Text = "Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10.2F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(327, 194);
            label4.Name = "label4";
            label4.Size = new Size(122, 19);
            label4.TabIndex = 8;
            label4.Text = "Package Session";
            // 
            // txtcountSession
            // 
            txtcountSession.BackColor = Color.FromArgb(47, 61, 71);
            txtcountSession.BorderStyle = BorderStyle.None;
            txtcountSession.ForeColor = Color.White;
            txtcountSession.Location = new Point(327, 225);
            txtcountSession.Multiline = true;
            txtcountSession.Name = "txtcountSession";
            txtcountSession.Size = new Size(228, 27);
            txtcountSession.TabIndex = 9;
            // 
            // txtPrice
            // 
            txtPrice.BackColor = Color.FromArgb(47, 61, 71);
            txtPrice.BorderStyle = BorderStyle.None;
            txtPrice.ForeColor = Color.White;
            txtPrice.Location = new Point(327, 299);
            txtPrice.Multiline = true;
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(228, 27);
            txtPrice.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10.2F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(327, 277);
            label5.Name = "label5";
            label5.Size = new Size(46, 19);
            label5.TabIndex = 11;
            label5.Text = "Price";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(61, 155, 150);
            label6.Location = new Point(165, 38);
            label6.Name = "label6";
            label6.Size = new Size(256, 32);
            label6.TabIndex = 12;
            label6.Text = "Add A new Package ";
            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.FromArgb(47, 61, 71);
            txtDescription.BorderStyle = BorderStyle.None;
            txtDescription.ForeColor = Color.White;
            txtDescription.Location = new Point(37, 469);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Type Here Something";
            txtDescription.Size = new Size(518, 100);
            txtDescription.TabIndex = 6;
            // 
            // comboInstructors
            // 
            comboInstructors.BackColor = Color.FromArgb(47, 61, 71);
            comboInstructors.DropDownStyle = ComboBoxStyle.DropDownList;
            comboInstructors.FlatStyle = FlatStyle.Flat;
            comboInstructors.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboInstructors.ForeColor = Color.White;
            comboInstructors.FormattingEnabled = true;
            comboInstructors.ItemHeight = 19;
            comboInstructors.Location = new Point(327, 418);
            comboInstructors.Name = "comboInstructors";
            comboInstructors.Size = new Size(228, 27);
            comboInstructors.Sorted = true;
            comboInstructors.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 10.2F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(327, 396);
            label7.Name = "label7";
            label7.Size = new Size(52, 19);
            label7.TabIndex = 14;
            label7.Text = "Coach";
            // 
            // AddPackageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(62, 78, 90);
            ClientSize = new Size(589, 656);
            Controls.Add(label7);
            Controls.Add(comboInstructors);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtPrice);
            Controls.Add(txtcountSession);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtDescription);
            Controls.Add(SaveNewPackage);
            Controls.Add(AddImage);
            Controls.Add(PictureAddPack);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddPackageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddPackageForm";
            Load += AddPackageForm_Load;
            ((System.ComponentModel.ISupportInitialize)PictureAddPack).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitle;
        private Label label2;
        private PictureBox PictureAddPack;
        private Button AddImage;
        private Button SaveNewPackage;
        private Label label3;
        private Label label4;
        private TextBox txtcountSession;
        private TextBox txtPrice;
        private Label label5;
        private Label label6;
        private TextBox txtDescription;
        private ComboBox comboInstructors;
        private Label label7;
    }
}
namespace GymMSWF
{
    partial class EditPackageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPackageForm));
            label1 = new Label();
            label4 = new Label();
            txtTitle = new TextBox();
            txtSessions = new TextBox();
            txtPrice = new TextBox();
            txtDescription = new TextBox();
            btnChangeImage = new Button();
            btnSaveChanges = new Button();
            label5 = new Label();
            picPackage = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            comboEditInstructor = new ComboBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)picPackage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            label1.Location = new Point(12, 77);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 0;
            label1.Text = "Title";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            label4.Location = new Point(12, 426);
            label4.Name = "label4";
            label4.Size = new Size(98, 20);
            label4.TabIndex = 3;
            label4.Text = "Description";
            // 
            // txtTitle
            // 
            txtTitle.BackColor = Color.FromArgb(47, 61, 71);
            txtTitle.Font = new Font("Times New Roman", 10.2F);
            txtTitle.ForeColor = Color.White;
            txtTitle.Location = new Point(12, 109);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(522, 34);
            txtTitle.TabIndex = 4;
            // 
            // txtSessions
            // 
            txtSessions.BackColor = Color.FromArgb(47, 61, 71);
            txtSessions.Font = new Font("Times New Roman", 10.2F);
            txtSessions.ForeColor = Color.White;
            txtSessions.Location = new Point(259, 305);
            txtSessions.Multiline = true;
            txtSessions.Name = "txtSessions";
            txtSessions.Size = new Size(241, 34);
            txtSessions.TabIndex = 5;
            // 
            // txtPrice
            // 
            txtPrice.BackColor = Color.FromArgb(47, 61, 71);
            txtPrice.Font = new Font("Times New Roman", 10.2F);
            txtPrice.ForeColor = Color.White;
            txtPrice.Location = new Point(259, 219);
            txtPrice.Multiline = true;
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(241, 34);
            txtPrice.TabIndex = 6;
            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.FromArgb(47, 61, 71);
            txtDescription.Font = new Font("Times New Roman", 10.2F);
            txtDescription.ForeColor = Color.White;
            txtDescription.Location = new Point(12, 452);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(522, 111);
            txtDescription.TabIndex = 7;
            // 
            // btnChangeImage
            // 
            btnChangeImage.BackColor = Color.FromArgb(61, 155, 150);
            btnChangeImage.FlatAppearance.BorderSize = 0;
            btnChangeImage.FlatStyle = FlatStyle.Flat;
            btnChangeImage.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btnChangeImage.ForeColor = Color.White;
            btnChangeImage.Location = new Point(154, 329);
            btnChangeImage.Name = "btnChangeImage";
            btnChangeImage.Size = new Size(41, 32);
            btnChangeImage.TabIndex = 8;
            btnChangeImage.Text = "...";
            btnChangeImage.UseVisualStyleBackColor = false;
            btnChangeImage.Click += btnChangeImage_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.BackColor = Color.FromArgb(61, 155, 150);
            btnSaveChanges.FlatAppearance.BorderSize = 0;
            btnSaveChanges.FlatStyle = FlatStyle.Flat;
            btnSaveChanges.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveChanges.ForeColor = Color.White;
            btnSaveChanges.Location = new Point(12, 579);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(525, 36);
            btnSaveChanges.TabIndex = 9;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = false;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(62, 78, 90);
            label5.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(61, 155, 150);
            label5.Location = new Point(188, 33);
            label5.Name = "label5";
            label5.Size = new Size(181, 35);
            label5.TabIndex = 10;
            label5.Text = "Edit Package";
            // 
            // picPackage
            // 
            picPackage.Location = new Point(12, 200);
            picPackage.Name = "picPackage";
            picPackage.Size = new Size(136, 161);
            picPackage.SizeMode = PictureBoxSizeMode.StretchImage;
            picPackage.TabIndex = 11;
            picPackage.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            label2.Location = new Point(259, 276);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 12;
            label2.Text = "Sessions";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            label3.Location = new Point(259, 192);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 13;
            label3.Text = "Price";
            // 
            // comboEditInstructor
            // 
            comboEditInstructor.BackColor = Color.FromArgb(47, 61, 71);
            comboEditInstructor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboEditInstructor.FlatStyle = FlatStyle.Flat;
            comboEditInstructor.ForeColor = Color.White;
            comboEditInstructor.FormattingEnabled = true;
            comboEditInstructor.Location = new Point(259, 426);
            comboEditInstructor.Name = "comboEditInstructor";
            comboEditInstructor.Size = new Size(241, 28);
            comboEditInstructor.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            label6.Location = new Point(259, 404);
            label6.Name = "label6";
            label6.Size = new Size(59, 20);
            label6.TabIndex = 15;
            label6.Text = "Coach";
            // 
            // EditPackageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(62, 78, 90);
            ClientSize = new Size(549, 627);
            Controls.Add(label6);
            Controls.Add(comboEditInstructor);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(picPackage);
            Controls.Add(label5);
            Controls.Add(btnSaveChanges);
            Controls.Add(btnChangeImage);
            Controls.Add(txtDescription);
            Controls.Add(txtPrice);
            Controls.Add(txtSessions);
            Controls.Add(txtTitle);
            Controls.Add(label4);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditPackageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditPackageForm";
            Load += EditPackageForm_Load;
            ((System.ComponentModel.ISupportInitialize)picPackage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label4;
        private TextBox txtTitle;
        private TextBox txtSessions;
        private TextBox txtPrice;
        private TextBox txtDescription;
        private Button btnChangeImage;
        private Button btnSaveChanges;
        private Label label5;
        private PictureBox picPackage;
        private Label label2;
        private Label label3;
        private ComboBox comboEditInstructor;
        private Label label6;
    }
}
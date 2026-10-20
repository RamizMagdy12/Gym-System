namespace GymMSWF
{
    partial class InstructorCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            insImage = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            insName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            insLname = new Guna.UI2.WinForms.Guna2HtmlLabel();
            insTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            insPhone = new Guna.UI2.WinForms.Guna2HtmlLabel();
            editIconButton = new FontAwesome.Sharp.IconButton();
            deleteInsIconButton = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)insImage).BeginInit();
            SuspendLayout();

            // insImage
            insImage.Anchor = AnchorStyles.None;
            insImage.ImageRotate = 0F;
            insImage.Location = new Point(37, 14);
            insImage.Name = "insImage";
            insImage.ShadowDecoration.CustomizableEdges = customizableEdges1;
            insImage.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            insImage.Size = new Size(153, 147);
            insImage.TabIndex = 0;
            insImage.TabStop = false;

            // insName
            insName.Anchor = AnchorStyles.None;
            insName.AutoSize = false;
            insName.BackColor = Color.Transparent;
            insName.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            insName.ForeColor = Color.White;
            insName.Location = new Point(41, 167);
            insName.Name = "insName";
            insName.Size = new Size(137, 21);
            insName.TabIndex = 3;
            insName.Text = "First Name";
            insName.TextAlignment = ContentAlignment.MiddleCenter;

            // insLname
            insLname.Anchor = AnchorStyles.None;
            insLname.AutoSize = false;
            insLname.BackColor = Color.Transparent;
            insLname.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            insLname.ForeColor = Color.White;
            insLname.Location = new Point(41, 194);
            insLname.Name = "insLname";
            insLname.Size = new Size(137, 21);
            insLname.TabIndex = 10;
            insLname.Text = "Last Name";
            insLname.TextAlignment = ContentAlignment.MiddleCenter;

            // insTitle
            insTitle.Anchor = AnchorStyles.None;
            insTitle.AutoSize = false;
            insTitle.BackColor = Color.Transparent;
            insTitle.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            insTitle.ForeColor = Color.White;
            insTitle.Location = new Point(53, 232);
            insTitle.Name = "insTitle";
            insTitle.Size = new Size(121, 31);
            insTitle.TabIndex = 4;
            insTitle.Text = "Trainer";
            insTitle.TextAlignment = ContentAlignment.MiddleCenter;

            // insPhone
            insPhone.Anchor = AnchorStyles.None;
            insPhone.AutoSize = false;
            insPhone.BackColor = Color.Transparent;
            insPhone.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            insPhone.ForeColor = Color.White;
            insPhone.Location = new Point(53, 269);
            insPhone.Name = "insPhone";
            insPhone.Size = new Size(125, 21);
            insPhone.TabIndex = 5;
            insPhone.Text = "01000000000";
            insPhone.TextAlignment = ContentAlignment.MiddleCenter;

            // editIconButton
            editIconButton.BackColor = Color.Transparent;
            editIconButton.FlatAppearance.BorderSize = 0;
            editIconButton.FlatStyle = FlatStyle.Flat;
            editIconButton.ForeColor = Color.Transparent;
            editIconButton.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            editIconButton.IconColor = Color.FromArgb(61, 155, 150);
            editIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            editIconButton.IconSize = 25;
            editIconButton.Location = new Point(182, 0);
            editIconButton.Name = "editIconButton";
            editIconButton.Size = new Size(31, 30);
            editIconButton.TabIndex = 7;
            editIconButton.UseVisualStyleBackColor = false;
            editIconButton.Click += editIconButton_Click;

            // deleteInsIconButton
            deleteInsIconButton.FlatAppearance.BorderSize = 0;
            deleteInsIconButton.FlatStyle = FlatStyle.Flat;
            deleteInsIconButton.ForeColor = Color.Transparent;
            deleteInsIconButton.IconChar = FontAwesome.Sharp.IconChar.Trash;
            deleteInsIconButton.IconColor = Color.FromArgb(61, 155, 150);
            deleteInsIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            deleteInsIconButton.IconSize = 25;
            deleteInsIconButton.Location = new Point(0, 0);
            deleteInsIconButton.Name = "deleteInsIconButton";
            deleteInsIconButton.Size = new Size(31, 30);
            deleteInsIconButton.TabIndex = 8;
            deleteInsIconButton.UseVisualStyleBackColor = true;
            deleteInsIconButton.Click += deleteInsIconButton_Click;

            // label1
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.FromArgb(52, 66, 76);
            label1.Location = new Point(10, 218);
            label1.Name = "label1";
            label1.Size = new Size(200, 2);
            label1.TabIndex = 9;

            // InstructorCard
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 61, 71);
            Controls.Add(insLname);
            Controls.Add(label1);
            Controls.Add(deleteInsIconButton);
            Controls.Add(editIconButton);
            Controls.Add(insPhone);
            Controls.Add(insTitle);
            Controls.Add(insName);
            Controls.Add(insImage);
            Name = "InstructorCard";
            Size = new Size(213, 302);
            ((System.ComponentModel.ISupportInitialize)insImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox insImage;
        private Guna.UI2.WinForms.Guna2HtmlLabel insName;
        private Guna.UI2.WinForms.Guna2HtmlLabel insLname;
        private Guna.UI2.WinForms.Guna2HtmlLabel insTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel insPhone;
        private FontAwesome.Sharp.IconButton editIconButton;
        private FontAwesome.Sharp.IconButton deleteInsIconButton;
        private Label label1;
    }
}

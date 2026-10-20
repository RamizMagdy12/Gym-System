namespace GymMSWF
{
    partial class FAQ
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
            faqPanel = new Guna.UI2.WinForms.Guna2Panel();
            SuspendLayout();
            // 
            // faqPanel
            // 
            faqPanel.AutoScroll = true;
            faqPanel.CustomizableEdges = customizableEdges1;
            faqPanel.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            faqPanel.ForeColor = Color.White;
            faqPanel.Location = new Point(21, 33);
            faqPanel.Name = "faqPanel";
            faqPanel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            faqPanel.Size = new Size(1157, 648);
            faqPanel.TabIndex = 0;
            // 
            // FAQ
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 48, 56);
            ClientSize = new Size(1227, 713);
            Controls.Add(faqPanel);
            Name = "FAQ";
            Text = "FAQ";
            Load += FAQForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel faqPanel;
    }
}
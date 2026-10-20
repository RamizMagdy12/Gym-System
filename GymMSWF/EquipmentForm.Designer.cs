namespace GymMSWF
{
    partial class EquipmentForm
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
            panel8 = new Panel();
            flowEquipments = new FlowLayoutPanel();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(36, 48, 56);
            panel8.Controls.Add(flowEquipments);
            panel8.Location = new Point(1, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(1077, 514);
            panel8.TabIndex = 12;
            // 
            // flowEquipments
            // 
            flowEquipments.AutoScroll = true;
            flowEquipments.Location = new Point(11, 12);
            flowEquipments.Name = "flowEquipments";
            flowEquipments.Size = new Size(1046, 471);
            flowEquipments.TabIndex = 1;
            // 
            // EquipmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 513);
            Controls.Add(panel8);
            Name = "EquipmentForm";
            Text = "EquipmentForm";
            Load += EquipmentForm_Load;
            panel8.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel8;
        private FlowLayoutPanel flowEquipments;
    }
}
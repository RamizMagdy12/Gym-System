using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace GymMSWF
{
    public partial class FAQ : Form
    {
        public FAQ()
        {
            InitializeComponent();
        }

        private void FAQForm_Load(object sender, EventArgs e)
        {
            // Enable scroll
            faqPanel.AutoScroll = true;

            // --- Gym & Instructors ---
            AddFAQ("How can I add a new instructor?",
                "Go to the Instructors page, click Add Instructor, fill in the details, and save.");

            AddFAQ("Can I assign members to specific instructors?",
                "Yes. When adding or editing a member, you can select the instructor responsible for their training plan.");

            AddFAQ("How do I update an instructor’s information?",
                "Open the Instructors page, select the instructor, and click Edit.");

            AddFAQ("Can I track how many members each instructor has?",
                "Yes. In the instructor details page, you can see all assigned members and their training status.");

            // --- System & Management ---
            AddFAQ("Can multiple users access the system at the same time?",
                "Yes, if your system is connected to a shared database or network, multiple staff members can use it simultaneously.");

            AddFAQ("What should I do if the system freezes or stops responding?",
                "Try restarting the application. If the issue persists, contact the administrator or technical support.");

            AddFAQ("Can I customize system colors or themes?",
                "Currently, customization is limited. Future updates may include theme options.");

            AddFAQ("How do I back up my data?",
                "Go to Settings → Backup to save a copy of your database.");

            // --- Packages & Subscriptions ---
            AddFAQ("How can I create new membership packages?",
                "Open the Packages page, click Add Package, and define the duration, price, and features.");

            AddFAQ("Can I edit a package after creating it?",
                "Yes, you can update its price or duration anytime from the Packages section.");

            AddFAQ("What happens when a package expires?",
                "The system can show a notification or mark the member as “Expired” until renewed.");

            AddFAQ("Can I offer discounts on packages?",
                "Yes. You can manually adjust the package price during member registration or renewal.");

            // --- Payment & Billing ---
            AddFAQ("How can I record a payment?",
                "Go to the Payments page, click Add Payment, select the member, and enter the amount paid.");

            AddFAQ("Does the system support partial payments?",
                "Yes. You can add multiple payments for the same membership until the full amount is covered.");

            AddFAQ("Can I view payment history for a specific member?",
                "Yes. Open the member’s profile and view all their payment transactions.");

            AddFAQ("Can I print payment receipts?",
                "Yes, after recording a payment, click Print Receipt to generate a printable invoice.");

            // --- Clients & Memberships ---
            AddFAQ("How do I add a new member?",
                "Go to the Members page, click Add Member, fill in personal details, select a package, and assign an instructor.");

            AddFAQ("Can I renew a member’s subscription?",
                "Yes. Select the member and click Renew Subscription, then choose the desired package and payment method.");

            AddFAQ("How can I mark attendance for members?",
                "From the Attendance section, select the date and mark the members who attended that day.");

            AddFAQ("Can I deactivate a member without deleting their data?",
                "Yes. You can mark a member as “Inactive” so their data stays in the system but they can’t access active services.");
        }

        private int currentY = 10; // المسافة الرأسية لكل سؤال/إجابة

        private void AddFAQ(string question, string answer)
        {
            // --- Question label ---
            Label questionLabel = new Label();
            questionLabel.Text = "Q: " + question;
            questionLabel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            questionLabel.AutoSize = true;
            questionLabel.ForeColor = Color.White;
           // questionLabel.MaximumSize = new Size(faqPanel.Width - 40, 0); // علشان يلف السطر
            questionLabel.Location = new Point(10, currentY);

            currentY += questionLabel.Height + 20; // مسافة بعد السؤال

            // --- Answer label ---
            Label answerLabel = new Label();
            answerLabel.Text = "A: " + answer;
            answerLabel.Font = new Font("Segoe UI", 10);
            answerLabel.AutoSize = true;
            answerLabel.ForeColor = Color.White;
           // answerLabel.MaximumSize = new Size(faqPanel.Width - 60, 0); // التفاف النص
            answerLabel.Location = new Point(25, currentY);

            currentY += answerLabel.Height + 40; // مسافة بين كل سؤال والتاني

            // --- Add to panel ---
            faqPanel.Controls.Add(questionLabel);
            faqPanel.Controls.Add(answerLabel);
        }

    }
}
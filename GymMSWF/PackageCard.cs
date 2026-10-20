using GymServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMSWF
{
    public partial class PackageCard : UserControl
    {
        private readonly PackageService _packageService;
        private readonly int _packageId;
        public PackageCard(int packageId, string name, decimal price, int sessions, string description, string imagepath)
        {
            InitializeComponent();
            var context = DbContext.CreateDbContext();
            _packageService = new PackageService(context);
            _packageId = packageId;
            this.Tag = packageId;
            lblName.Text = name;
            lblPrice.Text = $"${price:0.00} USD/package";
            lblSessions.Text = $"{sessions} sessions";
            lblDescription.Text = description;
            pictureBox1.Image = ImageFiles.TryLoad(imagepath) ?? ImageFiles.Placeholder(name, pictureBox1.Size);

        }

        private async void EditPackage_Click(object sender, EventArgs e)
        {
            using (EditPackageForm editForm = new EditPackageForm(_packageId))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    var updated = editForm.UpdatedPackage;
                    if (updated != null)
                    {

                        lblName.Text = updated.pack_title;
                        lblPrice.Text = $"${updated.pack_price:0.00} USD/package";
                        lblSessions.Text = $"{updated.pack_sessionsCount} sessions";
                        lblDescription.Text = updated.pack_desc;

                        pictureBox1.Image = ImageFiles.TryLoad(updated.pack_img)
                            ?? ImageFiles.Placeholder(updated.pack_title, pictureBox1.Size);


                        var parent = this.FindForm() as Packages;
                        if (parent != null)
                        {
                            var index = parent._allPackages.FindIndex(p => p.pack_id == updated.pack_id);
                            if (index >= 0)
                            {
                                parent._allPackages[index] = updated;
                            }
                        }
                    }
                }
            }
        }

        private async void DeletePackage_Click(object sender, EventArgs e)
        {
            

            var confirm = MessageBox.Show("Are you sure you want to delete this package?",
        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await _packageService.DeletePackageAsync(_packageId);
                    MessageBox.Show("✅ Package deleted successfully!");

                    // نحذف الكارت من الواجهة مباشرة
                    var parent = this.FindForm() as Packages;
                    if (parent != null)
                    {
                        parent.RemovePackageFromUI(_packageId); // ← استدعاء الميثود اللي فوق
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Error while deleting: {ex.Message}");
                }
            }
        }
    }
}

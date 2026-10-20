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
    public partial class Packages : Form
    {
        private readonly PackageService _packageService;
        public List<GymData.Models.Package> _allPackages = new();
        public Packages()
        {
            InitializeComponent();

            var context = DbContext.CreateDbContext();
            _packageService = new PackageService(context);
            ArrangePage();
            //this.Width = AppSettings.FormWidth;

           
            //this.MinimumSize = new Size(AppSettings.FormWidth, 0);
            //this.MaximumSize = new Size(AppSettings.FormWidth, 0);
        }


        private void DisplayPackages(List<GymData.Models.Package> packages)
        {
            flowPackages.Controls.Clear();

            foreach (var package in packages)
            {
                var card = new PackageCard(
                     package.pack_id,
                    package.pack_title,
                    package.pack_price,
                    package.pack_sessionsCount,
                    package.pack_desc,
                    package.pack_img
                );
                flowPackages.Controls.Add(card);
            }
        }

        public async Task LoadPackages()
        {
            flowPackages.Controls.Clear();

            _allPackages = await _packageService.GetAllPackages();
            DisplayPackages(_allPackages);
        }




        private void ArrangePage()
        {
            var page = Color.FromArgb(36, 48, 56);
            var field = Color.FromArgb(47, 61, 71);
            var accent = Color.FromArgb(61, 155, 150);

            BackColor = page;
            MainPanel.BackColor = page;
            MainPanel.Padding = new Padding(28, 16, 28, 16);

            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 52,
                BackColor = page
            };

            panel1.Parent = header;
            panel1.Dock = DockStyle.Left;
            panel1.Width = 380;
            panel1.Margin = new Padding(0);
            panel1.BackColor = field;

            SearchPackage.UseVisualStyleBackColor = false;
            SearchPackage.BackColor = field;
            SearchPackage.FlatAppearance.BorderSize = 0;
            SearchPackage.FlatAppearance.MouseOverBackColor = field;
            SearchPackage.IconColor = Color.FromArgb(186, 198, 206);
            SearchPackage.Dock = DockStyle.Left;
            SearchPackage.Width = 44;

            txtSearch.Multiline = false;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.BackColor = field;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Dock = DockStyle.None;
            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            void PlaceSearch()
            {
                txtSearch.Location = new Point(48, (panel1.Height - txtSearch.Height) / 2);
                txtSearch.Width = Math.Max(80, panel1.Width - 60);
            }
            panel1.Resize += (_, _) => PlaceSearch();
            PlaceSearch();
            panel1.Controls.SetChildIndex(txtSearch, 0);

            AddPackage.Parent = header;
            AddPackage.Dock = DockStyle.Right;
            AddPackage.Width = 150;
            AddPackage.Margin = new Padding(16, 0, 0, 0);
            AddPackage.BackColor = accent;
            AddPackage.FlatAppearance.BorderSize = 0;
            AddPackage.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 132, 128);
            AddPackage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            AddPackage.Text = "Add package";

            flowPackages.Dock = DockStyle.Fill;
            flowPackages.AutoSize = false;
            flowPackages.BackColor = page;
            flowPackages.Padding = new Padding(0, 18, 0, 0);
            flowPackages.Margin = new Padding(0);

            MainPanel.Controls.Add(header);
            MainPanel.Controls.SetChildIndex(flowPackages, 0);
            MainPanel.Controls.SetChildIndex(header, MainPanel.Controls.Count - 1);
        }

        private async void Packages_Load(object sender, EventArgs e)
        {
            await LoadPackages();
        }

        private async void AddPackage_Click(object sender, EventArgs e)
        {
            using var addPackageForm = new AddPackageForm();

            if (addPackageForm.ShowDialog() == DialogResult.OK)
            {
                var newPackage = addPackageForm.NewPackage;

                if (newPackage != null)
                {
                   
                    _allPackages.Add(newPackage);

                   
                    var card = new PackageCard(
                        newPackage.pack_id,
                        newPackage.pack_title,
                        newPackage.pack_price,
                        newPackage.pack_sessionsCount,
                        newPackage.pack_desc,
                        newPackage.pack_img
                    );

                    flowPackages.Controls.Add(card);
                }
            }
        }

        private void searchPackage()
        {
            if (_allPackages == null)
                return;

            string keyword = txtSearch.Text.Trim();
            var filtered = _allPackages
                .Where(p => (p.pack_title ?? "").Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();

            DisplayPackages(filtered);
        }

        private void SearchPackage_Click(object sender, EventArgs e)
        {
            searchPackage();
        }
        

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchPackage();
        }

        public void RemovePackageFromUI(int packageId)
        {
            // نحذف العنصر من القائمة في الذاكرة
            _allPackages.RemoveAll(p => p.pack_id == packageId);

            // نحذف الكارت من الواجهة فقط بدون إعادة تحميل الكل
            var cardToRemove = flowPackages.Controls
                .OfType<PackageCard>()
                .FirstOrDefault(c => (int)c.Tag == packageId);

            if (cardToRemove != null)
            {
                flowPackages.Controls.Remove(cardToRemove);
                cardToRemove.Dispose();
            }
        }


    }
}

using GymData.Models;
using GymServices;

namespace GymMSWF
{
    public partial class EquipmentForm : Form
    {
        private readonly EquipmentService _equipmentService;
        private List<Equipment> _equipments = new();
        private TextBox? _search;

        public EquipmentForm()
        {
            InitializeComponent();

            var context = DbContext.CreateDbContext();
            _equipmentService = new EquipmentService(context);
            BuildHeader();
        }

        private void BuildHeader()
        {
            panel8.Dock = DockStyle.Fill;
            flowEquipments.Dock = DockStyle.Fill;
            flowEquipments.Padding = new Padding(8);

            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 58,
                BackColor = Color.FromArgb(47, 61, 71)
            };

            _search = new TextBox
            {
                PlaceholderText = "Search equipment...",
                Location = new Point(16, 14),
                Size = new Size(280, 28),
                Font = new Font("Segoe UI", 10F)
            };
            _search.TextChanged += (_, _) => ShowEquipments(FilterEquipments());

            var addButton = new Button
            {
                Text = "Add equipment",
                Location = new Point(310, 12),
                Size = new Size(140, 32),
                BackColor = Color.FromArgb(74, 169, 81),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            addButton.FlatAppearance.BorderSize = 0;
            addButton.Click += (_, _) => EditEquipment(null);

            header.Controls.Add(_search);
            header.Controls.Add(addButton);
            Controls.Add(header);
            header.BringToFront();
        }

        private void EquipmentForm_Load(object sender, EventArgs e)
        {
            LoadEquipments();
        }

        private void LoadEquipments()
        {
            try
            {
                _equipments = _equipmentService.GetAll();
                ShowEquipments(FilterEquipments());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load equipment: " + ex.Message);
            }
        }

        private IEnumerable<Equipment> FilterEquipments()
        {
            string term = _search?.Text.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(term))
                return _equipments;

            return _equipments.Where(item =>
                (item.EquipName ?? "").Contains(term, StringComparison.OrdinalIgnoreCase)
                || (item.Category ?? "").Contains(term, StringComparison.OrdinalIgnoreCase));
        }

        private void ShowEquipments(IEnumerable<Equipment> equipments)
        {
            flowEquipments.Controls.Clear();
            foreach (var equipment in equipments)
            {
                var card = new EquipmentCard { Margin = new Padding(10) };
                card.SetData(equipment);
                card.EquipmentChanged += (_, _) => LoadEquipments();
                flowEquipments.Controls.Add(card);
            }
        }

        private void EditEquipment(Equipment? equipment)
        {
            using var editor = new EquipmentEditorForm(equipment);
            if (editor.ShowDialog(this) == DialogResult.OK)
                LoadEquipments();
        }
    }
}

using GymData.Models;
using GymServices;

namespace GymMSWF
{
    public partial class EquipmentCard : UserControl
    {
        private readonly EquipmentService _equipmentService;
        private Equipment? _equipment;
        public event EventHandler? EquipmentChanged;

        public EquipmentCard()
        {
            InitializeComponent();
            var context = DbContext.CreateDbContext();
            _equipmentService = new EquipmentService(context);
            AddActions();
        }

        public void SetData(Equipment equipment)
        {
            _equipment = equipment;
            EquipmentName.Text = equipment.EquipName;
            Category.Text = equipment.Category;
            Quantity.Text = equipment.Quantity.ToString();
            Price.Text = equipment.Price.ToString("C");
            PurchaseDate.Text = equipment.PurchaseDate.ToShortDateString();
            Condition.Text = equipment.Condition;
            MaintenanceDate.Text = equipment.MaintenanceDate?.ToShortDateString() ?? "N/A";
            EquipDescription.Text = equipment.EquipDescription;
            EmployeeId.Text = equipment.EmployeeId?.ToString() ?? "N/A";
        }

        private void AddActions()
        {
            Height = 392;

            var edit = CreateButton("Edit", new Point(16, 348), Color.FromArgb(61, 155, 150));
            edit.Click += (_, _) =>
            {
                if (_equipment == null)
                    return;

                using var editor = new EquipmentEditorForm(_equipment);
                if (editor.ShowDialog(FindForm()) == DialogResult.OK)
                    EquipmentChanged?.Invoke(this, EventArgs.Empty);
            };

            var delete = CreateButton("Delete", new Point(124, 348), Color.Firebrick);
            delete.Click += (_, _) => DeleteEquipment();

            Controls.Add(edit);
            Controls.Add(delete);
        }

        private static Button CreateButton(string text, Point location, Color backColor)
        {
            var button = new Button
            {
                Text = text,
                Location = location,
                Size = new Size(96, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = backColor,
                ForeColor = Color.White
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }

        private void DeleteEquipment()
        {
            if (_equipment == null)
                return;

            var confirm = MessageBox.Show(
                $"Delete {_equipment.EquipName}?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _equipmentService.Delete(_equipment.EquipmentId);
                EquipmentChanged?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete equipment: " + ex.Message);
            }
        }
    }
}

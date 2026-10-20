using GymData;
using GymData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymServices
{
    public class EquipmentService
    {
        private readonly GymContextDB _context;

        public EquipmentService(GymContextDB context)
        {
            _context = context;
        }

        public List<Equipment> GetAll()
        {
            return _context.Equipments.ToList();
        }

        public Equipment GetById(int id)
        {
            return _context.Equipments.FirstOrDefault(e => e.EquipmentId == id);
        }

        public void Add(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
            _context.SaveChanges();
        }

        public void Update(Equipment equipment)
        {
            var existing = _context.Equipments.Find(equipment.EquipmentId);
            if (existing == null)
                throw new InvalidOperationException("Equipment not found.");

            existing.EquipName = equipment.EquipName;
            existing.EquipDescription = equipment.EquipDescription;
            existing.Category = equipment.Category;
            existing.Quantity = equipment.Quantity;
            existing.Price = equipment.Price;
            existing.PurchaseDate = equipment.PurchaseDate;
            existing.Condition = equipment.Condition;
            existing.IsAvailable = equipment.IsAvailable;
            existing.MaintenanceDate = equipment.MaintenanceDate;
            existing.EmployeeId = equipment.EmployeeId;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var equipment = _context.Equipments.Find(id);
            if (equipment != null)
            {
                _context.Equipments.Remove(equipment);
                _context.SaveChanges();
            }
        }

    }
}

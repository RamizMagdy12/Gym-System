using GymData.Models;
using Microsoft.EntityFrameworkCore;


namespace GymData
{
    public class GymContextDB : DbContext
    {
        public GymContextDB(DbContextOptions<GymContextDB> options) : base(options) { }
		

		public DbSet<Client> client { get; set; } = null!;
        public DbSet<Instructor> instructors { get; set; } = null!;
        public DbSet<Payment> payment { get; set; } = null!;
        public DbSet<Package> package { get; set; } = null!;
        public DbSet<Employee> employees { get; set; } = null!;
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<FinanceRecord> FinanceRecords { get; set; } = null!;
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<AppRole> AppRoles { get; set; } = null!;
        public DbSet<RolePermission> RolePermissions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  Client → Package (many-to-one)
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Package)
                .WithMany(p => p.Members)
                .HasForeignKey(c => c.pack_id)
                .OnDelete(DeleteBehavior.Restrict);

            //  Payment → Client (many-to-one)
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Client)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.client_id)
                .OnDelete(DeleteBehavior.Cascade);

            //  Package → Instructor (many-to-one)
            modelBuilder.Entity<Package>()
                .HasOne(p => p.Instructor)
                .WithMany(i => i.Packages)
                .HasForeignKey(p => p.ins_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Package>()
                .Property(p => p.pack_price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(p => p.amount)
                .HasPrecision(18, 2);

            // Attendance → Client (many-to-one)
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Client)
                .WithMany()
                .HasForeignKey(a => a.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            // FinanceRecord → Employee (many-to-one)
            modelBuilder.Entity<FinanceRecord>()
                .HasOne(f => f.Employee)
                .WithMany()
                .HasForeignKey(f => f.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FinanceRecord>()
                .Property(f => f.ScheduledAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<FinanceRecord>()
                .Property(f => f.PaidAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<FinanceRecord>()
                .Property(f => f.Notes)
                .HasMaxLength(300);

            // Equipment
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Employee)
                .WithMany()
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.EquipName)
                .HasMaxLength(100);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.Category)
                .HasMaxLength(50);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.Condition)
                .HasMaxLength(50);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.EquipDescription)
                .HasMaxLength(300);

            modelBuilder.Entity<AppRole>()
                .Property(r => r.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<AppRole>()
                .HasIndex(r => r.Name)
                .IsUnique();

            modelBuilder.Entity<RolePermission>()
                .Property(p => p.Screen)
                .HasMaxLength(40);

            modelBuilder.Entity<RolePermission>()
                .HasOne(p => p.Role)
                .WithMany(r => r.Permissions)
                .HasForeignKey(p => p.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}

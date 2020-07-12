using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Zero.Core.Domain.Appointments;
using Zero.Core.Domain.Catalogs;
using Zero.Core.Domain.Customers;
using Zero.Core.Domain.Employees;
using Zero.Core.Domain.Settings;
using Zero.Core.Domain.Users;

namespace Zero.Data.EfContext
{
    public partial class ZeroDbContext : DbContext
    {
        public ZeroDbContext() : base("data source=PC\\SQLEXPRESS;initial catalog=ZeroDb;integrated security=True;")//MultipleActiveResultSets=True;App=EntityFramework
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();// remove => s

            modelBuilder.Entity<Appointment>()
            .Property(f => f.StartDate)
            .HasColumnType("datetime2");

            modelBuilder.Entity<Appointment>()
            .Property(f => f.EndDate)
            .HasColumnType("datetime2");

            modelBuilder.Entity<AppointmentSeance>()
            .Property(f => f.StartDate)
            .HasColumnType("datetime2");

            modelBuilder.Entity<AppointmentSeance>()
            .Property(f => f.EndDate)
            .HasColumnType("datetime2");

            modelBuilder.Entity<Customer>()
            .Property(f => f.DateOfBirth)
            .HasColumnType("datetime2");

            modelBuilder.Entity<Employee>()
            .Property(f => f.DateOfBirth)
            .HasColumnType("datetime2");

            modelBuilder.Entity<ApplicationUser>()
            .Property(f => f.DateOfBirth)
            .HasColumnType("datetime2");
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<AppointmentType> AppointmentType { get; set; }
        public virtual DbSet<AppointmentNote> AppointmentNote { get; set; }
        public virtual DbSet<AppointmentParticipant> AppointmentParticipant { get; set; }
        public virtual DbSet<AppointmentSeance> AppointmentSeance { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<TaxSetting> TaxSetting { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public virtual DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }
    }
}

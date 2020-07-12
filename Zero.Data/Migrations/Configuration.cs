using System;
using System.Data.Entity.Migrations;
using Zero.Core.Domain.Catalogs;
using Zero.Core.Domain.Customers;
using Zero.Core.Domain.Employees;
using Zero.Core.Domain.Users;
using Zero.Data.EfContext;
using FakeData;
using Zero.Core.Domain.Appointments;

namespace Zero.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ZeroDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ZeroDbContext context)
        {
            var admin = new ApplicationUser()
            {
                Id = 1,
                FirstName = "Ekin",
                LastName = "Memiş",
                Email = "ekinmemis@outlook.com",
                Password = "qwertyfy",
                Active = true,
                Deleted = false,
            };
            context.ApplicationUser.AddOrUpdate(admin);

            Random rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                Customer customer = new Customer
                {
                    Id = i,
                    Active = true,
                    DateOfBirth = DateTimeData.GetDatetime(),
                    Deleted = false,
                    Email = NetworkData.GetEmail(),
                    FirstName = NameData.GetFirstName(),
                    LastName = NameData.GetSurname(),
                    PalceOfBirth = FakeData.PlaceData.GetAddress(),
                    PhoneNumber = PhoneNumberData.GetPhoneNumber(),
                    TurkishIdentityNumber = NumberData.GetDouble().ToString(),
                };
                context.Customer.AddOrUpdate(customer);

                Employee employee = new Employee
                {
                    Id = i,
                    Active = true,
                    DateOfBirth = DateTimeData.GetDatetime(),
                    Deleted = false,
                    Email = NetworkData.GetEmail(),
                    FirstName = NameData.GetFirstName(),
                    LastName = NameData.GetSurname(),
                    PalceOfBirth = FakeData.PlaceData.GetAddress(),
                    PhoneNumber = PhoneNumberData.GetPhoneNumber(),
                    TurkishIdentityNumber = NumberData.GetDouble().ToString(),
                    Sallary = NumberData.GetNumber(),
                    Title = NameData.GetCompanyName()
                };
                context.Employee.AddOrUpdate(employee);

                AppointmentType appointmentType = new AppointmentType
                {
                    Id = i,
                    DefaultSeanceQuantity = NumberData.GetNumber(1, 10),
                    Name = TextData.GetAlphabetical(5),
                    Deleted = false,
                };
                context.AppointmentType.AddOrUpdate(appointmentType);

                Appointment appointment = new Appointment
                {
                    Id = i,
                    Deleted = false,
                    StartDate = DateTimeData.GetDatetime(),
                    EndDate = DateTimeData.GetDatetime(),
                    Price = NumberData.GetNumber(),
                    PriceIncludedTax = NumberData.GetNumber(),
                    Name = TextData.GetAlphabetical(5),
                    AppointmentStatusId = 0,
                    AppointmentTypeId = rnd.Next(100),
                };
                context.Appointment.AddOrUpdate(appointment);
            }
        }
    }
}

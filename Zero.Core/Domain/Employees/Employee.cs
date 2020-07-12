using System;

namespace Zero.Core.Domain.Employees
{
    public class Employee : BaseEntity
    {
        public string TurkishIdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public decimal Sallary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PalceOfBirth { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }
}

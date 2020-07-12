using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zero.Web.Models.Customer
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string TurkishIdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PalceOfBirth { get; set; }
        public bool Active { get; set; }
    }
}
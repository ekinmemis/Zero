using System;

namespace Zero.Core.Domain.Appointments
{
    public class AppointmentSeance : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public decimal PriceIncludedTax { get; set; }
        public bool Deleted { get; set; }

        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}

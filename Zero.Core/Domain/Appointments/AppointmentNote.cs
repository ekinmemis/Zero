namespace Zero.Core.Domain.Appointments
{
    public class AppointmentNote : BaseEntity
    {
        public string Description { get; set; }
        public bool Deleted { get; set; }

        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}

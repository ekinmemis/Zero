using System.ComponentModel.DataAnnotations.Schema;

namespace Zero.Core.Domain.Appointments
{
    public class AppointmentParticipant : BaseEntity
    {
        public int EntityId { get; set; }

        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }

        public int ParticipantTypeId { get; set; }
        [NotMapped]
        public AppointmentParticipantType ParticipantType
        {

            get
            {
                return (AppointmentParticipantType)ParticipantTypeId;
            }
            set
            {
                ParticipantTypeId = (int)value;
            }
        }
    }
}

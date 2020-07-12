using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zero.Core.Domain.Appointments
{
    public class AppointmentType : BaseEntity
    {
        public string Name { get; set; }
        public int DefaultSeanceQuantity { get; set; }
        public bool Deleted { get; set; }

        public int AppointmentPeriodeTypeId { get; set; }
        [NotMapped]
        public AppointmentPeriodeType AppointmentPeriodeType
        {
            get
            {
                return (AppointmentPeriodeType)this.AppointmentPeriodeTypeId;
            }
            set
            {
                this.AppointmentPeriodeTypeId = (int)value;
            }
        }

        public virtual List<Appointment> Appointments { get; set; }
    }
}

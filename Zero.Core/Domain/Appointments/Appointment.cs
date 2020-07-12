using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zero.Core.Domain.Appointments
{
    public class Appointment : BaseEntity
    {
        public Appointment()
        {
            this.AppointmentNotes = new List<AppointmentNote>();
            this.AppointmentSeances = new List<AppointmentSeance>();
            this.AppointmentParticipants = new List<AppointmentParticipant>();
        }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public decimal PriceIncludedTax { get; set; }
        public int AppointmentTypeId { get; set; }
        public bool Deleted { get; set; }

        public int AppointmentStatusId { get; set; }
        [NotMapped]
        public AppointmentStatus AppointmentStatus
        {
            get
            {
                return (AppointmentStatus)AppointmentStatusId;
            }
            set
            {
                AppointmentStatusId = (int)value;
            }
        }

        public virtual List<AppointmentNote> AppointmentNotes { get; set; }
        public virtual List<AppointmentSeance> AppointmentSeances { get; set; }
        public virtual List<AppointmentParticipant> AppointmentParticipants { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Zero.Web.Models.Appointment
{
    public class AppointmentModel
    {
        public AppointmentModel()
        {
            this.AvailableAppointmentStatus = new List<SelectListItem>();
            this.AvailableAppointmentTypes = new List<SelectListItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public decimal PriceIncludedTax { get; set; }

        public int AppointmentStatusId { get; set; }
        public IList<SelectListItem> AvailableAppointmentStatus { get; set; }

        public int AppointmentTypeId { get; set; }
        public IList<SelectListItem> AvailableAppointmentTypes { get; set; }
    }
}
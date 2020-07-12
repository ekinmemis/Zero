using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Zero.Web.Models.AppointmentType
{
    public class AppointmentTypeModel
    {
        public AppointmentTypeModel()
        {
            this.AvailableAppointmentPeriodeTypes = new List<SelectListItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DefaultSeanceQuantity { get; set; }


        public int AppointmentPeriodeTypeId { get; set; }
        public IList<SelectListItem> AvailableAppointmentPeriodeTypes { get; set; }
    }
}
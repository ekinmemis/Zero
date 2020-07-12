using System.ComponentModel;

namespace Zero.Web.Models.Appointment
{
    public class AppointmentListModel : DataTableRequestModel
    {
        public string SearchName { get; set; }
    }
}
using Zero.Core;
using Zero.Core.Domain.Appointments;

namespace Zero.Service.Appointments
{
    public interface IAppointmentTypeService
    {
        IPagedList<AppointmentType> GetAllAppointmentTypes(string name = "", int pageIndex = 0, int pageSize = int.MaxValue);

        AppointmentType GetAppointmentTypeById(int id);

        void InsertAppointmentType(AppointmentType appointmentType);

        void UpdateAppointmentType(AppointmentType appointmentType);

        void DeleteAppointmentType(AppointmentType appointmentType);
    }
}

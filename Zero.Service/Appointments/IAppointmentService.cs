using Zero.Core;
using Zero.Core.Domain.Appointments;

namespace Zero.Service.Appointments
{
    public interface IAppointmentService
    {
        IPagedList<Appointment> GetAllAppointments(string name = "", int pageIndex = 0, int pageSize = int.MaxValue);

        Appointment GetAppointmentById(int id);

        void InsertAppointment(Appointment appointment);

        void UpdateAppointment(Appointment appointment);

        void DeleteAppointment(Appointment appointment);
    }
}

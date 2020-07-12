using System;
using System.Linq;
using Zero.Core;
using Zero.Core.Domain.Appointments;
using Zero.Data.EfRepository;

namespace Zero.Service.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> _appointmentRepository;

        public AppointmentService()
        {
            this._appointmentRepository = new Repository<Appointment>();
        }

        public IPagedList<Appointment> GetAllAppointments(string name, int pageIndex, int pageSize)
        {
            var query = _appointmentRepository.Table;

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            query = query.Where(f => f.Deleted == false);

            query = query.OrderBy(o => o.Id);

            var appointment = new PagedList<Appointment>(query, pageIndex, pageSize);

            return appointment;
        }

        public Appointment GetAppointmentById(int id)
        {
            if (id == 0)
                throw (new ArgumentNullException("parameter missing"));

            var appointment = _appointmentRepository.GetById(id);

            return appointment;
        }

        public void InsertAppointment(Appointment appointment)
        {
            if (appointment == null)
                throw (new ArgumentNullException("parameter missing"));

            _appointmentRepository.Insert(appointment);
        }

        public void UpdateAppointment(Appointment appointment)
        {
            if (appointment == null)
                throw (new ArgumentNullException("parameter missing"));

            _appointmentRepository.Update(appointment);
        }

        public void DeleteAppointment(Appointment appointment)
        {
            if (appointment == null)
                throw (new ArgumentNullException("parameter missing"));

            _appointmentRepository.Delete(appointment);
        }
    }
}

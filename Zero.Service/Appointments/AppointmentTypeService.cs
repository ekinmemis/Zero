using System;
using System.Linq;
using Zero.Core;
using Zero.Core.Domain.Appointments;
using Zero.Data.EfRepository;

namespace Zero.Service.Appointments
{
    public class AppointmentTypeService : IAppointmentTypeService
    {
        private readonly IRepository<AppointmentType> _appointmentTypeRepository;

        public AppointmentTypeService()
        {
            this._appointmentTypeRepository = new Repository<AppointmentType>();
        }

        public IPagedList<AppointmentType> GetAllAppointmentTypes(string name, int pageIndex, int pageSize)
        {
            var query = _appointmentTypeRepository.Table;

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            query = query.Where(f => f.Deleted == false);

            query = query.OrderBy(o => o.Id);

            var appointmentType = new PagedList<AppointmentType>(query, pageIndex, pageSize);

            return appointmentType;
        }

        public AppointmentType GetAppointmentTypeById(int id)
        {
            if (id == 0)
                throw (new ArgumentNullException("parameter missing"));

            var appointmentType = _appointmentTypeRepository.GetById(id);

            return appointmentType;
        }

        public void InsertAppointmentType(AppointmentType appointmentType)
        {
            if (appointmentType == null)
                throw (new ArgumentNullException("parameter missing"));

            _appointmentTypeRepository.Insert(appointmentType);
        }

        public void UpdateAppointmentType(AppointmentType appointmentType)
        {
            if (appointmentType == null)
                throw (new ArgumentNullException("parameter missing"));

            _appointmentTypeRepository.Update(appointmentType);
        }

        public void DeleteAppointmentType(AppointmentType appointmentType)
        {
            if (appointmentType == null)
                throw (new ArgumentNullException("parameter missing"));

            _appointmentTypeRepository.Delete(appointmentType);
        }
    }
}

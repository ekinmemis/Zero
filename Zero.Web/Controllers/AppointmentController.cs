using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Zero.Core.Domain.Appointments;
using Zero.Service.Appointments;
using Zero.Web.Models.Appointment;

namespace Zero.Web.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAppointmentTypeService _appointmentTypeService;

        public AppointmentController()
        {
            _appointmentService = new AppointmentService();
            _appointmentTypeService = new AppointmentTypeService();
        }


        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new AppointmentListModel());
        }

        [HttpPost]
        public ActionResult AppointmentList(AppointmentListModel model)
        {
            var appointments = _appointmentService.GetAllAppointments(
                name: model.SearchName,
                pageIndex: model.PageIndex,
                pageSize: model.PageSize);

            return Json(new
            {
                draw = model.Draw,
                recordsFiltered = 0,
                recordsTotal = appointments.TotalCount,
                data = appointments
            });
        }

        public ActionResult Create()
        {
            var model = new AppointmentModel
            {
                AvailableAppointmentStatus = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text = "Beklemede",
                        Value = ((int)AppointmentStatus.Pending).ToString(),
                    },
                    new SelectListItem
                    {
                        Text = "Onaylandı",
                        Value = ((int)AppointmentStatus.Approved).ToString(),
                    },
                    new SelectListItem
                    {
                        Text = "Tamamlandı",
                        Value = ((int)AppointmentStatus.Completed).ToString(),
                    },
                },
                AvailableAppointmentTypes = _appointmentTypeService
                                            .GetAllAppointmentTypes()
                                            .Select(f => new SelectListItem { Text = f.Name, Value = f.Id.ToString() })
                                            .ToList()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AppointmentModel model)
        {
            if (ModelState.IsValid)
            {
                var appointment = new Appointment
                {
                    Id = model.Id,
                    Name = model.Name,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Price = model.Price,
                    PriceIncludedTax = model.PriceIncludedTax,
                    AppointmentTypeId = model.AppointmentTypeId,
                    AppointmentStatusId = model.AppointmentStatusId,
                };

                _appointmentService.InsertAppointment(appointment);

                if (string.IsNullOrEmpty(Request["saveandcontinue"]))
                    return RedirectToAction("List");

                if (string.IsNullOrEmpty(Request["save"]))
                    return RedirectToAction("Edit", new { id = appointment.Id });
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var appointment = _appointmentService.GetAppointmentById(id);

            if (appointment == null || appointment.Deleted)
                return RedirectToAction("List");

            var model = new AppointmentModel()
            {
                Id = appointment.Id,
                Name = appointment.Name,
                StartDate = appointment.StartDate,
                EndDate = appointment.EndDate,
                Price = appointment.Price,
                PriceIncludedTax = appointment.PriceIncludedTax,
                AppointmentStatusId = appointment.AppointmentStatusId,
                AppointmentTypeId = appointment.AppointmentTypeId,
            };

            model.AvailableAppointmentStatus = new List<SelectListItem>
            {
                 new SelectListItem
                 {
                     Text = "Beklemede",
                     Value = ((int)AppointmentStatus.Pending).ToString(),
                 },
                 new SelectListItem
                 {
                     Text = "Onaylandı",
                     Value = ((int)AppointmentStatus.Approved).ToString(),
                 },
                 new SelectListItem
                 {
                     Text = "Tamamlandı",
                     Value = ((int)AppointmentStatus.Completed).ToString(),
                 },
            };

            model.AvailableAppointmentStatus.FirstOrDefault(f => f.Value == model.AppointmentStatusId.ToString()).Selected = true;

            model.AvailableAppointmentTypes = _appointmentTypeService.
                    GetAllAppointmentTypes()
                    .Select(f => new SelectListItem { Text = f.Name, Value = f.Id.ToString(), Selected = f.Id == model.AppointmentTypeId ? true : false })
                    .ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AppointmentModel model)
        {
            if (ModelState.IsValid)
            {
                var appointment = _appointmentService.GetAppointmentById(model.Id);

                if (appointment == null || appointment.Deleted)
                    return RedirectToAction("List");

                appointment.Id = model.Id;
                appointment.Name = model.Name;
                appointment.StartDate = model.StartDate;
                appointment.EndDate = model.EndDate;
                appointment.Price = model.Price;
                appointment.PriceIncludedTax = model.PriceIncludedTax;
                appointment.AppointmentStatusId = model.AppointmentStatusId;
                appointment.AppointmentTypeId = model.AppointmentTypeId;

                _appointmentService.UpdateAppointment(appointment);

                if (string.IsNullOrEmpty(Request["save"]))
                    return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var appointment = _appointmentService.GetAppointmentById(id);

            if (appointment == null)
                return Json("ERR");

            appointment.Deleted = true;

            _appointmentService.UpdateAppointment(appointment);

            return Json("OK");
        }
    }
}
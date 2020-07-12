using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Zero.Core.Domain.Appointments;
using Zero.Service.Appointments;
using Zero.Web.Models.AppointmentType;

namespace Zero.Web.Controllers
{
    public class AppointmentTypeController : Controller
    {
        private readonly IAppointmentTypeService _appointmentTypeService;


        public AppointmentTypeController()
        {
            _appointmentTypeService = new AppointmentTypeService();
        }


        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new AppointmentTypeListModel());
        }

        [HttpPost]
        public ActionResult AppointmentTypeList(AppointmentTypeListModel model)
        {
            var appointmentTypes = _appointmentTypeService.GetAllAppointmentTypes(
                name: model.SearchName,
                pageIndex: model.PageIndex,
                pageSize: model.PageSize);

            return Json(new
            {
                draw = model.Draw,
                recordsFiltered = 0,
                recordsTotal = appointmentTypes.TotalCount,
                data = appointmentTypes
            });
        }

        public ActionResult Create()
        {
            var model = new AppointmentTypeModel
            {
                AvailableAppointmentPeriodeTypes = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                         Text="Saat",
                         Value=((int)AppointmentPeriodeType.Hours).ToString(),
                    },
                    new SelectListItem
                    {
                         Text="Gün",
                         Value=((int)AppointmentPeriodeType.Days).ToString(),
                    },
                    new SelectListItem
                    {
                         Text="Hafta",
                         Value=((int)AppointmentPeriodeType.Weeks).ToString(),
                    },
                    new SelectListItem
                    {
                         Text="Ay",
                         Value=((int)AppointmentPeriodeType.Months).ToString(),
                    },
                    new SelectListItem
                    {
                         Text="Yıl",
                         Value=((int)AppointmentPeriodeType.Years).ToString(),
                    },
                }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AppointmentTypeModel model)
        {
            if (ModelState.IsValid)
            {
                var appointmentType = new AppointmentType
                {
                    Id = model.Id,
                    Name = model.Name,
                    DefaultSeanceQuantity = model.DefaultSeanceQuantity,
                    AppointmentPeriodeTypeId = model.AppointmentPeriodeTypeId,
                };

                _appointmentTypeService.InsertAppointmentType(appointmentType);

                if (string.IsNullOrEmpty(Request["saveandcontinue"]))
                    return RedirectToAction("List");

                if (string.IsNullOrEmpty(Request["save"]))
                    return RedirectToAction("Edit", new { id = appointmentType.Id });
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var appointmentType = _appointmentTypeService.GetAppointmentTypeById(id);

            if (appointmentType == null || appointmentType.Deleted)
                return RedirectToAction("List");

            var model = new AppointmentTypeModel()
            {
                Id = appointmentType.Id,
                Name = appointmentType.Name,
                DefaultSeanceQuantity = appointmentType.DefaultSeanceQuantity,
                AppointmentPeriodeTypeId = appointmentType.AppointmentPeriodeTypeId,
            };

            model.AvailableAppointmentPeriodeTypes = new List<SelectListItem>
            {
                new SelectListItem
                {
                     Text="Saat",
                     Value=((int)AppointmentPeriodeType.Hours).ToString(),
                },
                new SelectListItem
                {
                     Text="Gün",
                     Value=((int)AppointmentPeriodeType.Days).ToString(),
                },
                new SelectListItem
                {
                     Text="Hafta",
                     Value=((int)AppointmentPeriodeType.Weeks).ToString(),
                },
                new SelectListItem
                {
                     Text="Ay",
                     Value=((int)AppointmentPeriodeType.Months).ToString(),
                },
                new SelectListItem
                {
                     Text="Yıl",
                     Value=((int)AppointmentPeriodeType.Years).ToString(),
                },
            };
            //Seçili gelmesi için
            model.AvailableAppointmentPeriodeTypes.FirstOrDefault(f => f.Value == model.AppointmentPeriodeTypeId.ToString()).Selected = true;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AppointmentTypeModel model)
        {
            if (ModelState.IsValid)
            {
                var appointmentType = _appointmentTypeService.GetAppointmentTypeById(model.Id);

                if (appointmentType == null || appointmentType.Deleted)
                    return RedirectToAction("List");

                appointmentType.Id = model.Id;
                appointmentType.Name = model.Name;
                appointmentType.DefaultSeanceQuantity = model.DefaultSeanceQuantity;
                appointmentType.AppointmentPeriodeTypeId = model.AppointmentPeriodeTypeId;

                _appointmentTypeService.UpdateAppointmentType(appointmentType);

                if (string.IsNullOrEmpty(Request["save"]))
                    return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var appointmentType = _appointmentTypeService.GetAppointmentTypeById(id);

            if (appointmentType == null)
                return Json("ERR");

            appointmentType.Deleted = true;

            _appointmentTypeService.UpdateAppointmentType(appointmentType);

            return Json("OK");
        }
    }
}
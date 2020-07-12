using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zero.Web.Models.Employee
{
    public class EmployeeListModel : DataTableRequestModel
    {
        public string SearchEmail { get; set; }
        public string SearchTitle { get; set; }
        public string SearchFirstName { get; set; }
        public string SearchLastName { get; set; }
        public string SearchPhone { get; set; }
        public decimal Sallary { get; set; }
    }
}
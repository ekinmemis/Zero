using Zero.Core;
using Zero.Core.Domain.Taxes;

namespace Zero.Service.Taxes
{
    public interface ITaxService
    {
        IPagedList<Tax> GetAllTaxs(int pageIndex = 0, int pageSize = int.MaxValue);

        Tax GetTaxById(int id);

        void InsertTax(Tax tax);

        void UpdateTax(Tax tax);

        void DeleteTax(Tax tax);
    }
}

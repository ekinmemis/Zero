using System;
using System.Linq;
using Zero.Core;
using Zero.Core.Domain.Taxes;
using Zero.Data.EfRepository;

namespace Zero.Service.Taxes
{
    public class TaxService : ITaxService
    {
        private IRepository<Tax> _taxRepository;

        public TaxService()
        {
            this._taxRepository = new Repository<Tax>();
        }

        public IPagedList<Tax> GetAllTaxs(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _taxRepository.Table;

            query = query.Where(f => f.Deleted == false);

            query.OrderBy(o => o.Id);

            var taxs = new PagedList<Tax>(query, pageIndex, pageSize);

            return taxs;
        }

        public Tax GetTaxById(int id)
        {

            if (id == 0)
                throw (new ArgumentNullException("parameter missing"));

            var tax = _taxRepository.GetById(id);

            return tax;
        }

        public void InsertTax(Tax tax)
        {
            if (tax == null)
                throw (new ArgumentNullException("parameter missing"));

            _taxRepository.Insert(tax);
        }

        public void UpdateTax(Tax tax)
        {
            if (tax == null)
                throw (new ArgumentNullException("parameter missing"));

            _taxRepository.Update(tax);
        }

        public void DeleteTax(Tax tax)
        {
            if (tax == null)
                throw (new ArgumentNullException("parameter missing"));

            _taxRepository.Delete(tax);
        }
    }
}

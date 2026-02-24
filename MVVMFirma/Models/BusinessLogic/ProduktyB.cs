using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class ProduktyB:DatabaseClass
    {
        #region Constructor
        public ProduktyB(SklepEntities db) : 
            base(db) { }
        #endregion
        #region BusinessFunctions
        public IQueryable<KeyAndValue> GetProduktyKeyAndValueItems()
        {
            return
                (
                from nazwa in db.Produkt
                select new KeyAndValue
                {
                    Key = nazwa.IdProduktu,
                    Value = nazwa.Nazwa
                }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}

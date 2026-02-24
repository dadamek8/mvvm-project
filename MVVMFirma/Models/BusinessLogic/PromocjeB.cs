using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class PromocjeB : DatabaseClass
    {
        #region Constructor
        public PromocjeB(SklepEntities db) :
            base(db)
        { }
        #endregion
        #region BusinessFunctions
        public IQueryable<KeyAndValue> GetPromocjeKeyAndValueItems()
        {
            return
                (
                from nazwa in db.Promocja
                select new KeyAndValue
                {
                    Key = nazwa.IdPromocji,
                    Value = nazwa.Nazwa
                }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}

using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class StatusyB : DatabaseClass
    {
        #region Constructor
        public StatusyB(SklepEntities db) :
            base(db)
        { }
        #endregion
        #region BusinessFunctions
        public IQueryable<KeyAndValue> GetStatusyKeyAndValueItems()
        {
            return
                (
                from status in db.Status
                select new KeyAndValue
                {
                    Key = status.IdStatusu,
                    Value = status.Nazwa
                }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}

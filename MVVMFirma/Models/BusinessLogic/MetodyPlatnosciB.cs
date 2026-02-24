using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class MetodyPlatnosciB : DatabaseClass
    {
        #region Constructor
        public MetodyPlatnosciB(SklepEntities db) :
            base(db)
        { }
        #endregion
        #region BusinessFunctions
        public IQueryable<KeyAndValue> GetMetodyPlatnosciKeyAndValueItems()
        {
            return
                (
                from metodaplatnosci in db.MetodaPlatnosci
                select new KeyAndValue
                {
                    Key = metodaplatnosci.IdMetodyPlatnosci,
                    Value = metodaplatnosci.Nazwa
                }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}

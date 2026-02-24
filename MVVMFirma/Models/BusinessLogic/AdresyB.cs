using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class AdresyB : DatabaseClass
    {
        #region Constructor
        public AdresyB(SklepEntities db) :
            base(db)
        { }
        #endregion
        #region BusinessFunctions
        public IQueryable<KeyAndValue> GetAdresyKeyAndValueItems()
        {
            return
                (
                from adres in db.Adres
                select new KeyAndValue
                {
                    Key = adres.IdAdresu,
                    Value = adres.Miejscowosc + " " + adres.Ulica + " " + adres.NrDomu + (string.IsNullOrEmpty(adres.NrLokalu) ? "" : "/" + adres.NrLokalu) + " " + adres.KodPocztowy + " " + adres.Poczta
                }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}

using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class ZamowieniaB : DatabaseClass
    {
        #region Constructor
        public ZamowieniaB(SklepEntities db) :
            base(db)
        { }
        #endregion
        #region BusinessFunctions
        public IQueryable<KeyAndValue> GetZamowieniaKeyAndValueItems()
        {
            return
                (
                from nazwa in db.Zamowienie
                select new KeyAndValue
                {
                    Key = nazwa.IdZamowienia,
                    Value = nazwa.IdZamowienia.ToString()
                }
                ).ToList().AsQueryable();
        }
        #endregion
    }

}

using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class KlienciB:DatabaseClass
    {
        #region Constructor
        public KlienciB(SklepEntities db) :
            base(db)
        { }
        #endregion
        #region BusinessFunctions
        public IQueryable<KeyAndValue> GetKlienciKeyAndValueItems()
        {
            return
                (
                from klient in db.Klient
                select new KeyAndValue
                {
                    Key = klient.IdKlienta,
                    Value = klient.Email + " " + klient.Telefon
                }
                ).ToList().AsQueryable();
        }
        public IQueryable<KeyAndValue> GetKlienciEmailKeyAndValueItems()
        {
            return
                (
                from klient in db.Klient
                select new KeyAndValue
                {
                    Key = klient.IdKlienta,
                    Value = klient.Email
                }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}

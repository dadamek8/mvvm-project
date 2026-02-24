using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class StatusyZamowienB : DatabaseClass
    {
        #region Constructor
        public StatusyZamowienB(SklepEntities db) :
            base(db)
        { }
        #endregion
        #region BusinessFunctions
        public int? StatusyZamowienOkres(int idStatusu, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from zamowienie in db.Zamowienie
                where zamowienie.IdStatusu == idStatusu &&
                zamowienie.DataZlozenia >= dataOd &&
                zamowienie.DataZlozenia <= dataDo
                select zamowienie
            ).Count();
        }
        public int? IloscZamowienOkres(DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from zamowienie in db.Zamowienie
                where zamowienie.DataZlozenia >= dataOd &&
                zamowienie.DataZlozenia <= dataDo
                select zamowienie
            ).Count();
        }
        #endregion
    }
}

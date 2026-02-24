using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class HistoriaZamowienB : DatabaseClass
    {
        #region Constructor
        public HistoriaZamowienB(SklepEntities db) :
            base(db)
        { }
        #endregion
        #region BusinessFunctions
        public List<HistoriaZamowienForView> GetZamowieniaKlienta(int idKlienta, DateTime dataOd, DateTime dataDo)
        {
            return (from zamowienie in db.Zamowienie
                    where zamowienie.IdKlienta == idKlienta &&
                          zamowienie.DataZlozenia >= dataOd &&
                          zamowienie.DataZlozenia <= dataDo
                    select new HistoriaZamowienForView
                    {
                        IdZamowienia = zamowienie.IdZamowienia,
                        KwotaZamowienia = zamowienie.KwotaZamowienia,
                        DataZlozenia = zamowienie.DataZlozenia,
                        MetodaPlatnosci = zamowienie.MetodaPlatnosci.Nazwa,
                        Status = zamowienie.Status.Nazwa
                    }).ToList();
        }
    }
    #endregion
}

using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class SprzedaneSztukiB:DatabaseClass
    {
        #region Constructor
        public SprzedaneSztukiB(SklepEntities db) :
            base(db) { }
        #endregion
        #region BusinessFunctions
        public int? SprzedaneSztukiOkres(int idProduktu, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from pozycja in db.PozycjaZamowienia
                where pozycja.IdProduktu == idProduktu &&
                pozycja.Zamowienie.DataZlozenia >= dataOd &&
                pozycja.Zamowienie.DataZlozenia <= dataDo
                select pozycja.Ilosc
                ).Sum() ?? 0;
        }
    #endregion
}
    }

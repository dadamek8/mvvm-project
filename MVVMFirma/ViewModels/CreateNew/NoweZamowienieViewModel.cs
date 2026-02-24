using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NoweZamowienieViewModel : JedenViewModel<Zamowienie>
    {
        #region Constructor
        public NoweZamowienieViewModel()
            : base("Zamowienie")
        {
            item = new Zamowienie();
        }
        #endregion
        #region Properties
        public int? IdKlienta
        {
            get
            {
                return item.IdKlienta;
            }
            set
            {
                item.IdKlienta = value;
                OnPropertyChanged(() => IdKlienta);
            }
        }
        public int? IdMetodyPlatnosci
        {
            get
            {
                return item.IdMetodyPlatnosci;
            }
            set
            {
                item.IdMetodyPlatnosci = value;
                OnPropertyChanged(() => IdMetodyPlatnosci);
            }
        }
        public DateTime? DataZlozenia
        {
            get
            {
                return item.DataZlozenia;
            }
            set
            {
                item.DataZlozenia = value;
                OnPropertyChanged(() => DataZlozenia);
            }
        }
        public int? IdStatusu
        {
            get
            {
                return item.IdStatusu;
            }
            set
            {
                item.IdStatusu = value;
                OnPropertyChanged(() => IdStatusu);
            }
        }
        public decimal? KwotaZamowienia
        {
            get
            {
                return item.KwotaZamowienia;
            }
            set
            {
                item.KwotaZamowienia = value;
                OnPropertyChanged(() => KwotaZamowienia);
            }
        }
        #endregion
        #region ComboBoxProperties
        public IQueryable<KeyAndValue> KlienciItems
        {
            get
            {
                return new KlienciB(sklepEntities).GetKlienciEmailKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValue> MetodyPlatnosciItems
        {
            get
            {
                return new MetodyPlatnosciB(sklepEntities).GetMetodyPlatnosciKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValue> StatusyItems
        {
            get
            {
                return new StatusyB(sklepEntities).GetStatusyKeyAndValueItems();
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            sklepEntities.Zamowienie.Add(item);
            sklepEntities.SaveChanges();
        }
        #endregion
    }
}

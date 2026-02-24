using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowyProduktViewModel : JedenViewModel<Produkt>
    {
        #region Constructor
        public NowyProduktViewModel()
            : base("Produkt")
        {
            item = new Produkt();
        }
        #endregion
        #region Properties
        public string Kod
        {
            get
            {
                return item.Kod;
            }
            set
            {
                item.Kod = value;
                OnPropertyChanged(() => Kod);
            }
        }
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                item.Nazwa = value;
                OnPropertyChanged(() => Nazwa);
            }
        }
        public decimal? CenaZakupu
        {
            get
            {
                return item.CenaZakupu;
            }
            set
            {
                item.CenaZakupu = value;
                OnPropertyChanged(() => CenaZakupu);
            }
        }
        public decimal? CenaSprzedazy
        {
            get
            {
                return item.CenaSprzedazy;
            }
            set
            {
                item.CenaSprzedazy = value;
                OnPropertyChanged(() => CenaSprzedazy);
            }
        }
        public int? DostepnaIlosc
        {
            get
            {
                return item.DostepnaIlosc;
            }
            set
            {
                item.DostepnaIlosc = value;
                OnPropertyChanged(() => DostepnaIlosc);
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            sklepEntities.Produkt.Add(item);
            sklepEntities.SaveChanges();
        }
        #endregion
    }
}

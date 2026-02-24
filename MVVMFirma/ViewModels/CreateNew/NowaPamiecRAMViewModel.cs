using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowaPamiecRAMViewModel : JedenViewModel<PamiecRAM>
    {
        #region Constructor
        public NowaPamiecRAMViewModel()
            : base("PamiecRAM")
        {
            item = new PamiecRAM();
            Messenger.Default.Register<Produkt>(this, getWybranyProdukt);
        }
        #endregion
        #region Properties
        public int? IdProduktu
        {
            get
            {
                return item.IdProduktu;
            }
            set
            {
                item.IdProduktu = value;
                OnPropertyChanged(() => IdProduktu);
            }
        }
        public string ProduktNazwa { get; set; }
        public string Producent
        {
            get
            {
                return item.Producent;
            }
            set
            {
                item.Producent = value;
                OnPropertyChanged(() => Producent);
            }
        }
        public int? LacznaPojemnosc
        {
            get
            {
                return item.LacznaPojemnosc;
            }
            set
            {
                item.LacznaPojemnosc = value;
                OnPropertyChanged(() => LacznaPojemnosc);
            }
        }
        public string TypPamieci
        {
            get
            {
                return item.TypPamieci;
            }
            set
            {
                item.TypPamieci = value;
                OnPropertyChanged(() => TypPamieci);
            }
        }
        public string CzestotliwoscPracy
        {
            get
            {
                return item.CzestotliwoscPracy;
            }
            set
            {
                item.CzestotliwoscPracy = value;
                OnPropertyChanged(() => CzestotliwoscPracy);
            }
        }
        public int? LiczbaModulow
        {
            get
            {
                return item.LiczbaModulow;
            }
            set
            {
                item.LiczbaModulow = value;
                OnPropertyChanged(() => LiczbaModulow);
            }
        }
        #endregion
        #region ComboBoxProperties
        public IQueryable<KeyAndValue> ProduktyItems
        {
            get
            {
                return new ProduktyB(sklepEntities).GetProduktyKeyAndValueItems();
            }
        }
        #endregion
        #region Commands
        private BaseCommand _ShowProdukty;
        public ICommand ShowProdukty
        {
            get
            {
                if (_ShowProdukty == null)
                    _ShowProdukty = new BaseCommand(() => showProdukty());
                return _ShowProdukty;
            }
        }
        private void showProdukty()
        {
            Messenger.Default.Send<string>("ProduktyAll");
        }
        #endregion

        #region Helpers
        private void getWybranyProdukt(Produkt produkt)
        {
            IdProduktu = produkt.IdProduktu;
            ProduktNazwa = produkt.Nazwa;
        }

        public override void Save()
        {
            sklepEntities.PamiecRAM.Add(item);
            sklepEntities.SaveChanges();
        }
        #endregion
    }
}

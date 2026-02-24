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
    public class NowaPlytaGlownaViewModel : JedenViewModel<PlytaGlowna>
    {
        #region Constructor
        public NowaPlytaGlownaViewModel()
            : base("PlytaGlowna")
        {
            item = new PlytaGlowna();
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
        public string GniazdoProcesora
        {
            get
            {
                return item.GniazdoProcesora;
            }
            set
            {
                item.GniazdoProcesora = value;
                OnPropertyChanged(() => GniazdoProcesora);
            }
        }
        public int? SlotyPamieci
        {
            get
            {
                return item.SlotyPamieci;
            }
            set
            {
                item.SlotyPamieci = value;
                OnPropertyChanged(() => SlotyPamieci);
            }
        }
        public bool? WiFi
        {
            get
            {
                return item.WiFi;
            }
            set
            {
                item.WiFi = value;
                OnPropertyChanged(() => WiFi);
            }
        }
        public bool? Bluetooth
        {
            get
            {
                return item.Bluetooth;
            }
            set
            {
                item.Bluetooth = value;
                OnPropertyChanged(() => Bluetooth);
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
            sklepEntities.PlytaGlowna.Add(item);
            sklepEntities.SaveChanges();
        }
        #endregion
    }
}

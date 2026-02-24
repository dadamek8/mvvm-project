using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowaKartaGraficznaViewModel:JedenViewModel<KartaGraficzna>
    {
        #region Constructor
        public NowaKartaGraficznaViewModel()
            : base("KartaGraficzna")
        {
            item = new KartaGraficzna();
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
        public string ProducentKarty
        {
            get
            {
                return item.ProducentKarty;
            }
            set
            {
                item.ProducentKarty = value;
                OnPropertyChanged(() => ProducentKarty);
            }
        }
        public string ProducentChipsetu
        {
            get
            {
                return item.ProducentChipsetu;
            }
            set
            {
                item.ProducentChipsetu = value;
                OnPropertyChanged(() => ProducentChipsetu);
            }
        }
        public string Chipset
        {
            get
            {
                return item.Chipset;
            }
            set
            {
                item.Chipset = value;
                OnPropertyChanged(() => Chipset);
            }
        }
        public int? RAM
        {
            get
            {
                return item.RAM;
            }
            set
            {
                item.RAM = value;
                OnPropertyChanged(() => RAM);
            }
        }
        public int? TaktowanieRdzenia
        {
            get
            {
                return item.TaktowanieRdzenia;
            }
            set
            {
                item.TaktowanieRdzenia = value;
                OnPropertyChanged(() => TaktowanieRdzenia);
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
            sklepEntities.KartaGraficzna.Add(item);
            sklepEntities.SaveChanges();
        }
        #endregion
    }
}

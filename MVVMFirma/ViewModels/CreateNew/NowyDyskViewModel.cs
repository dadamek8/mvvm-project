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
    public class NowyDyskViewModel : JedenViewModel<Dysk>
    {
        #region Constructor
        public NowyDyskViewModel()
            : base("Dysk")
        {
            item = new Dysk();
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
        public string Rodzaj
        {
            get
            {
                return item.Rodzaj;
            }
            set
            {
                item.Rodzaj = value;
                OnPropertyChanged(() => Rodzaj);
            }
        }
        public string Format
        {
            get
            {
                return item.Format;
            }
            set
            {
                item.Format = value;
                OnPropertyChanged(() => Format);
            }
        }
        public int? Pojemnosc
        {
            get
            {
                return item.Pojemnosc;
            }
            set
            {
                item.Pojemnosc = value;
                OnPropertyChanged(() => Pojemnosc);
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
            sklepEntities.Dysk.Add(item);
            sklepEntities.SaveChanges();
        }
        #endregion
    }
}


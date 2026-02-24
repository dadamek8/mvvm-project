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
    public class NowyProcesorViewModel:JedenViewModel<Procesor>
    {
        #region Constructor
        public NowyProcesorViewModel()
            : base("Procesor")
        {
            item = new Procesor();
            Messenger.Default.Register<Produkt>(this, getWybranyProdukt);
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
        public int? LiczbaRdzeni
        {
            get
            {
                return item.LiczbaRdzeni;
            }
            set
            {
                item.LiczbaRdzeni = value;
                OnPropertyChanged(() => LiczbaRdzeni);
            }
        }
        public int? LiczbaWatkow
        {
            get
            {
                return item.LiczbaWatkow;
            }
            set
            {
                item.LiczbaWatkow = value;
                OnPropertyChanged(() => LiczbaWatkow);
            }
        }
        public decimal? Taktowanie
        {
            get
            {
                return item.Taktowanie;
            }
            set
            {
                item.Taktowanie = value;
                OnPropertyChanged(() => Taktowanie);
            }
        }
        public string TypGniazda
        {
            get
            {
                return item.TypGniazda;
            }
            set
            {
                item.TypGniazda = value;
                OnPropertyChanged(() => TypGniazda);
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
        #region Helpers
        private void getWybranyProdukt(Produkt produkt)
        {
            IdProduktu = produkt.IdProduktu;
            ProduktNazwa = produkt.Nazwa;
        }
        public override void Save()
        {
            sklepEntities.Procesor.Add(item);
            sklepEntities.SaveChanges();
        }
        #endregion
    }
}

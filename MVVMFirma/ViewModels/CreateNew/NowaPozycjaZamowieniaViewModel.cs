using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Models.Validatory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowaPozycjaZamowieniaViewModel : JedenViewModel<PozycjaZamowienia>, IDataErrorInfo
    {
        #region Constructor
        public NowaPozycjaZamowieniaViewModel()
            : base("PozycjaZamowienia")
        {
            item = new PozycjaZamowienia();
            Messenger.Default.Register<Produkt>(this, getWybranyProdukt);
            Messenger.Default.Register<ZamowienieForAllView>(this, getWybraneZamowienie);
            Messenger.Default.Register<Promocja>(this, getWybranaPromocja);
        }
        #endregion
        #region Properties
        public int? IdZamowienia
        {
            get
            {
                return item.IdZamowienia;
            }
            set
            {
                item.IdZamowienia = value;
                OnPropertyChanged(() => IdZamowienia);
            }
        }
        public string ProduktNazwa { get; set; }
        public int? IdPromocji
        {
            get
            {
                return item.IdPromocji;
            }
            set
            {
                item.IdPromocji = value;
                OnPropertyChanged(() => IdPromocji);
            }
        }
        public string PromocjaNazwa { get; set; }
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
        public int? ZamowienieId { get; set; }
        public int? Ilosc
        {
            get
            {
                return item.Ilosc;
            }
            set
            {
                item.Ilosc = value;
                OnPropertyChanged(() => Ilosc);
            }
        }
        public decimal? CenaCalkowita
        {
            get
            {
                return item.CenaCalkowita;
            }
            set
            {
                item.CenaCalkowita = value;
                OnPropertyChanged(() => CenaCalkowita);
            }
        }
        #endregion
        #region ComboBoxProperties
        public IQueryable<KeyAndValue> ZamowieniaItems
        {
            get
            {
                return new ZamowieniaB(sklepEntities).GetZamowieniaKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValue> PromocjeItems
        {
            get
            {
                return new PromocjeB(sklepEntities).GetPromocjeKeyAndValueItems();
            }
        }
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
        private BaseCommand _ShowZamowienia;
        public ICommand ShowZamowienia
        {
            get
            {
                if (_ShowZamowienia == null)
                    _ShowZamowienia = new BaseCommand(() => showZamowienia());
                return _ShowZamowienia;
            }
        }
        private void showZamowienia()
        {
            Messenger.Default.Send<string>("ZamowieniaAll");
        }
        private BaseCommand _ShowPromocje;
        public ICommand ShowPromocje
        {
            get
            {
                if (_ShowPromocje == null)
                    _ShowPromocje = new BaseCommand(() => showPromocje());
                return _ShowPromocje;
            }
        }
        private void showPromocje()
        {
            Messenger.Default.Send<string>("PromocjeAll");
        }
        #endregion

        #region Helpers
        private void getWybranyProdukt(Produkt produkt)
        {
            IdProduktu = produkt.IdProduktu;
            ProduktNazwa = produkt.Nazwa;
        }
        private void getWybraneZamowienie(ZamowienieForAllView zamowienie)
        {
            IdZamowienia = zamowienie.IdZamowienia;
            ZamowienieId = zamowienie.IdZamowienia;
        }
        private void getWybranaPromocja(Promocja promocja)
        {
            IdPromocji = promocja.IdPromocji;
            PromocjaNazwa = promocja.Nazwa;
        }
        public override void Save()
        {
            sklepEntities.PozycjaZamowienia.Add(item);
            sklepEntities.SaveChanges();
        }
        #endregion
        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Ilosc")
                    komunikat = BiznesValidator.SprawdzIloscOrazCene(this.Ilosc);
                if (name == "CenaCalkowita")
                    komunikat = BiznesValidator.SprawdzIloscOrazCene(this.CenaCalkowita);
                return komunikat;
            }
        }
        public override bool isValid()
        {
            if (this["Ilosc"] == null && this["CenaCalkowita"] == null)
                return true;
            return false;
        }
        #endregion

    }
}

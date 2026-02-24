using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszyscyKlienciViewModel : WszystkieViewModel<KlientForAllView>
    {
        #region Constructor
        public WszyscyKlienciViewModel()
            : base("Klienci")
        {
        }
        #endregion
        #region Properties
        private KlientForAllView _WybranyKlient;
        public KlientForAllView WybranyKlient
        {
            get
            {
                return _WybranyKlient;
            }
            set
            {
                _WybranyKlient = value;
                Messenger.Default.Send(_WybranyKlient);
                OnRequestClose();
            }
        }
        #endregion
        #region Sort And Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "rodzaj klienta", "data rejestracji" };
        }
        public override void Sort()
        {
            if (SortField == "rodzaj klienta")
                List = new ObservableCollection<KlientForAllView>(List.OrderBy(item => item.RodzajKlienta));
            if (SortField == "data rejestracji")
                List = new ObservableCollection<KlientForAllView>(List.OrderBy(item => item.DataRejestracji));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "rodzaj klienta", "e-mail", "telefon" };
        }
        public override void Find()
        {
            if (FindField == "rodzaj klienta")
                List = new ObservableCollection<KlientForAllView>(List.Where(item => item.RodzajKlienta != null && item.RodzajKlienta.StartsWith(FindTextBox)));
            if (FindField == "e-mail")
                List = new ObservableCollection<KlientForAllView>(List.Where(item => item.Email != null && item.Email.StartsWith(FindTextBox)));
            if (FindField == "telefon")
                List = new ObservableCollection<KlientForAllView>(List.Where(item => item.Telefon != null && item.Telefon.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KlientForAllView>
                (
                    from klient in sklepEntities.Klient
                    select new KlientForAllView
                    {
                        IdKlienta = klient.IdKlienta,
                        RodzajKlienta = klient.RodzajKlienta,
                        Email = klient.Email,
                        Telefon = klient.Telefon,
                        AdresMiejscowosc = klient.Adres.Miejscowosc,
                        AdresUlica = klient.Adres.Ulica,
                        AdresNrDomu = klient.Adres.NrDomu,
                        AdresNrLokalu = klient.Adres.NrLokalu,
                        AdresKodPocztowy = klient.Adres.KodPocztowy,
                        AdresPoczta = klient.Adres.Poczta,
                        DataRejestracji = klient.DataRejestracji
                    }
                );
        }
        #endregion
    }
}

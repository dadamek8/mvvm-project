using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class WszystkieProduktyViewModel : WszystkieViewModel<Produkt>
    {
        #region Constructor
        public WszystkieProduktyViewModel()
            : base("Produkty")
        {
        }
        #endregion
        #region Properties
        private Produkt _WybranyProdukt;
        public Produkt WybranyProdukt
        {
            get
            {
                return _WybranyProdukt;
            }
            set
            {
                _WybranyProdukt = value;
                Messenger.Default.Send(_WybranyProdukt);
                OnRequestClose();
            }
        }
        #endregion
        #region Sort And Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "kod", "nazwa", "cena zakupu", "cena sprzedazy", "dostepna ilosc" };
        }
        public override void Sort()
        {
            if (SortField == "kod")
                List = new ObservableCollection<Produkt>(List.OrderBy(item => item.Kod));
            if (SortField == "nazwa")
                List = new ObservableCollection<Produkt>(List.OrderBy(item => item.Nazwa));
            if (SortField == "cena zakupu")
                List = new ObservableCollection<Produkt>(List.OrderBy(item => item.CenaZakupu));
            if (SortField == "cena sprzedazy")
                List = new ObservableCollection<Produkt>(List.OrderBy(item => item.CenaSprzedazy));
            if (SortField == "dostepna ilosc")
                List = new ObservableCollection<Produkt>(List.OrderBy(item => item.DostepnaIlosc));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "kod", "nazwa"};
        }
        public override void Find()
        {
            if (FindField == "kod")
                List = new ObservableCollection<Produkt>(List.Where(item => item.Kod != null && item.Kod.StartsWith(FindTextBox)));
            if (FindField == "nazwa")
                List = new ObservableCollection<Produkt>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Produkt>
                (
                sklepEntities.Produkt.ToList()
                );
        }
        #endregion
    }
}

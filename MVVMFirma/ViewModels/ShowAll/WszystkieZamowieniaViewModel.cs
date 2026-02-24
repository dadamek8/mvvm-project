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
    public class WszystkieZamowieniaViewModel : WszystkieViewModel<ZamowienieForAllView>
    {
        #region Constructor
        public WszystkieZamowieniaViewModel()
            : base("Zamowienia")
        {
        }
        #endregion
        #region Properties
        private ZamowienieForAllView _WybraneZamowienie;
        public ZamowienieForAllView WybraneZamowienie
        {
            get
            {
                return _WybraneZamowienie;
            }
            set
            {
                _WybraneZamowienie = value;
                Messenger.Default.Send(_WybraneZamowienie);
                OnRequestClose();
            }
        }
        #endregion
        #region Sort And Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "data zlozenia", "kwota zamowienia" };
        }
        public override void Sort()
        {
            if (SortField == "data zlozenia")
                List = new ObservableCollection<ZamowienieForAllView>(List.OrderBy(item => item.DataZlozenia));
            if (SortField == "kwota zamowienia")
                List = new ObservableCollection<ZamowienieForAllView>(List.OrderBy(item => item.KwotaZamowienia));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "e-mail", "metoda platnosci", "status" };
        }
        public override void Find()
        {
            if (FindField == "e-mail")
                List = new ObservableCollection<ZamowienieForAllView>(List.Where(item => item.KlientEmail != null && item.KlientEmail.StartsWith(FindTextBox)));
            if (FindField == "metoda platnosci")
                List = new ObservableCollection<ZamowienieForAllView>(List.Where(item => item.MetodaPlatnosciNazwa != null && item.MetodaPlatnosciNazwa.StartsWith(FindTextBox)));
            if (FindField == "status")
                List = new ObservableCollection<ZamowienieForAllView>(List.Where(item => item.StatusNazwa != null && item.StatusNazwa.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZamowienieForAllView>
                (
                    from zamowienie in sklepEntities.Zamowienie
                    select new ZamowienieForAllView
                    {
                        IdZamowienia = zamowienie.IdZamowienia,
                        KlientEmail = zamowienie.Klient.Email,
                        MetodaPlatnosciNazwa = zamowienie.MetodaPlatnosci.Nazwa,
                        DataZlozenia = zamowienie.DataZlozenia,
                        StatusNazwa = zamowienie.Status.Nazwa,
                        KwotaZamowienia = zamowienie.KwotaZamowienia
                    }
                );
        }
        #endregion
    }
}

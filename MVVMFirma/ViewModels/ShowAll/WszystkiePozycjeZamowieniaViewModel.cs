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
    public class WszystkiePozycjeZamowieniaViewModel : WszystkieViewModel<PozycjaZamowieniaForAllView>
    {
        #region Constructor
        public WszystkiePozycjeZamowieniaViewModel()
            : base("PozycjeZamowienia")
        {
        }
        #endregion
        #region Sort And Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "nazwa promocji", "nazwa produktu", "ilosc", "cena calkowita" };
        }
        public override void Sort()
        {
            if (SortField == "nazwa promocji")
                List = new ObservableCollection<PozycjaZamowieniaForAllView>(List.OrderBy(item => item.PromocjaNazwa));
            if (SortField == "nazwa produktu")
                List = new ObservableCollection<PozycjaZamowieniaForAllView>(List.OrderBy(item => item.ProduktNazwa));
            if (SortField == "ilosc")
                List = new ObservableCollection<PozycjaZamowieniaForAllView>(List.OrderBy(item => item.Ilosc));
            if (SortField == "cena calkowita")
                List = new ObservableCollection<PozycjaZamowieniaForAllView>(List.OrderBy(item => item.CenaCalkowita));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "nazwa promocji", "nazwa produktu" };
        }
        public override void Find()
        {
            if (FindField == "nazwa promocji")
                List = new ObservableCollection<PozycjaZamowieniaForAllView>(List.Where(item => item.PromocjaNazwa != null && item.PromocjaNazwa.StartsWith(FindTextBox)));
            if (FindField == "nazwa produktu")
                List = new ObservableCollection<PozycjaZamowieniaForAllView>(List.Where(item => item.ProduktNazwa != null && item.ProduktNazwa.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PozycjaZamowieniaForAllView>
                (
                    from pozycjaZamowienia in sklepEntities.PozycjaZamowienia
                    select new PozycjaZamowieniaForAllView
                    {
                        IdPozycjiZamowienia = pozycjaZamowienia.IdPozycjiZamowienia,
                        ZamowienieId = pozycjaZamowienia.Zamowienie.IdZamowienia.ToString(),
                        PromocjaNazwa = pozycjaZamowienia.Promocja.Nazwa,
                        ProduktNazwa = pozycjaZamowienia.Produkt.Nazwa,
                        Ilosc = pozycjaZamowienia.Ilosc,
                        CenaCalkowita = pozycjaZamowienia.CenaCalkowita
                    }
                );
        }
        #endregion
    }
}

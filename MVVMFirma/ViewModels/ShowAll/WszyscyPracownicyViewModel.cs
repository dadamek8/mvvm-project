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
    public class WszyscyPracownicyViewModel : WszystkieViewModel<PracownikForAllView>
    {
        #region Constructor
        public WszyscyPracownicyViewModel()
            : base("Pracownicy")
        {
        }
        #endregion
        #region Sort And Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "imie", "nazwisko", "stanowisko" };
        }
        public override void Sort()
        {
            if (SortField == "imie")
                List = new ObservableCollection<PracownikForAllView>(List.OrderBy(item => item.Imie));
            if (SortField == "nazwisko")
                List = new ObservableCollection<PracownikForAllView>(List.OrderBy(item => item.Nazwisko));
            if (SortField == "stanowisko")
                List = new ObservableCollection<PracownikForAllView>(List.OrderBy(item => item.Stanowisko));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "imie", "nazwisko", "stanowisko", "telefon", "e-mail" };
        }
        public override void Find()
        {
            if (FindField == "imie")
                List = new ObservableCollection<PracownikForAllView>(List.Where(item => item.Imie != null && item.Imie.StartsWith(FindTextBox)));
            if (FindField == "nazwisko")
                List = new ObservableCollection<PracownikForAllView>(List.Where(item => item.Nazwisko != null && item.Nazwisko.StartsWith(FindTextBox)));
            if (FindField == "stanowisko")
                List = new ObservableCollection<PracownikForAllView>(List.Where(item => item.Stanowisko != null && item.Stanowisko.StartsWith(FindTextBox)));
            if (FindField == "telefon")
                List = new ObservableCollection<PracownikForAllView>(List.Where(item => item.Telefon != null && item.Telefon.StartsWith(FindTextBox)));
            if (FindField == "e-mail")
                List = new ObservableCollection<PracownikForAllView>(List.Where(item => item.Email != null && item.Email.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PracownikForAllView>
                (
                    from pracownik in sklepEntities.Pracownik
                    select new PracownikForAllView
                    {
                        IdPracownika = pracownik.IdPracownika,
                        Imie = pracownik.Imie,
                        Nazwisko = pracownik.Nazwisko,
                        Stanowisko = pracownik.Stanowisko,
                        Email = pracownik.Email,
                        Telefon = pracownik.Telefon,
                        AdresMiejscowosc = pracownik.Adres.Miejscowosc,
                        AdresUlica = pracownik.Adres.Ulica,
                        AdresNrDomu = pracownik.Adres.NrDomu,
                        AdresNrLokalu = pracownik.Adres.NrLokalu,
                        AdresKodPocztowy = pracownik.Adres.KodPocztowy,
                        AdresPoczta = pracownik.Adres.Poczta,
                    }
                );
        }
        #endregion
    }
}

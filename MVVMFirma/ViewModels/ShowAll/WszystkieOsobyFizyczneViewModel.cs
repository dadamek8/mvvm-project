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
    public class WszystkieOsobyFizyczneViewModel : WszystkieViewModel<OsobaFizycznaForAllView>
    {
        #region Constructor
        public WszystkieOsobyFizyczneViewModel()
            : base("OsobyFizyczne")
        {
        }
        #endregion
        #region Sort And Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "imie", "nazwisko" };
        }
        public override void Sort()
        {
            if (SortField == "imie")
                List = new ObservableCollection<OsobaFizycznaForAllView>(List.OrderBy(item => item.Imie));
            if (SortField == "nazwisko")
                List = new ObservableCollection<OsobaFizycznaForAllView>(List.OrderBy(item => item.Nazwisko));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "imie", "nazwisko", "e-mail", "telefon" };
        }
        public override void Find()
        {
            if (FindField == "imie")
                List = new ObservableCollection<OsobaFizycznaForAllView>(List.Where(item => item.Imie != null && item.Imie.StartsWith(FindTextBox)));
            if (FindField == "nazwisko")
                List = new ObservableCollection<OsobaFizycznaForAllView>(List.Where(item => item.Nazwisko != null && item.Nazwisko.StartsWith(FindTextBox)));
            if (FindField == "e-mail")
                List = new ObservableCollection<OsobaFizycznaForAllView>(List.Where(item => item.KlientEmail != null && item.KlientEmail.StartsWith(FindTextBox)));
            if (FindField == "telefon")
                List = new ObservableCollection<OsobaFizycznaForAllView>(List.Where(item => item.KlientTelefon != null && item.KlientTelefon.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<OsobaFizycznaForAllView>
                (
                    from osobaFizyczna in sklepEntities.OsobaFizyczna
                    select new OsobaFizycznaForAllView
                    {
                        IdOsobyFizycznej = osobaFizyczna.IdOsobyFizycznej,
                        Imie = osobaFizyczna.Imie,
                        Nazwisko = osobaFizyczna.Nazwisko,
                        KlientEmail = osobaFizyczna.Klient.Email,
                        KlientTelefon = osobaFizyczna.Klient.Telefon
                    }
                );
        }
        #endregion
    }
}

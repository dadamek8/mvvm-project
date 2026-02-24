using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class WszystkieProcesoryViewModel : WszystkieViewModel<ProcesorForAllView>
    {
        #region Constructor
        public WszystkieProcesoryViewModel()
            : base("Procesory")
        {
        }
        #endregion
        #region Sort And Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "nazwa", "producent", "liczba rdzeni", "liczba watkow", "taktowanie" };
        }
        public override void Sort()
        {
            if (SortField == "nazwa")
                List = new ObservableCollection<ProcesorForAllView>(List.OrderBy(item => item.ProduktNazwa));
            if (SortField == "producent")
                List = new ObservableCollection<ProcesorForAllView>(List.OrderBy(item => item.Producent));
            if (SortField == "liczba rdzeni")
                List = new ObservableCollection<ProcesorForAllView>(List.OrderBy(item => item.LiczbaRdzeni));
            if (SortField == "liczba watkow")
                List = new ObservableCollection<ProcesorForAllView>(List.OrderBy(item => item.LiczbaWatkow));
            if (SortField == "taktowanie")
                List = new ObservableCollection<ProcesorForAllView>(List.OrderBy(item => item.Taktowanie));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "nazwa", "producent", "typ gniazda"};
        }
        public override void Find()
        {
            if (FindField == "nazwa")
                List = new ObservableCollection<ProcesorForAllView>(List.Where(item => item.ProduktNazwa != null && item.ProduktNazwa.StartsWith(FindTextBox)));
            if (FindField == "producent")
                List = new ObservableCollection<ProcesorForAllView>(List.Where(item => item.Producent != null && item.Producent.StartsWith(FindTextBox)));
            if (FindField == "typ gniazda")
                List = new ObservableCollection<ProcesorForAllView>(List.Where(item => item.TypGniazda != null && item.TypGniazda.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ProcesorForAllView>
                (
                    from procesor in sklepEntities.Procesor
                    select new ProcesorForAllView
                    {
                        IdProcesora = procesor.IdProcesora,
                        ProduktNazwa = procesor.Produkt.Nazwa,
                        Producent = procesor.Producent,
                        LiczbaRdzeni = procesor.LiczbaRdzeni,
                        LiczbaWatkow = procesor.LiczbaWatkow,
                        Taktowanie = procesor.Taktowanie,
                        TypGniazda = procesor.TypGniazda

                    }
                );
        }
        #endregion
    }


}

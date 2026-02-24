using MVVMFirma.Models.BusinessLogic;
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
    public class WszystkieDyskiViewModel : WszystkieViewModel<DyskForAllView>
    {
        #region Constructor
        public WszystkieDyskiViewModel()
            : base("Dyski")
        {
        }
        #endregion
        #region Sort And Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "nazwa", "producent", "rodzaj", "pojemnosc" };
        }
        public override void Sort()
        {
            if (SortField == "nazwa")
                List = new ObservableCollection<DyskForAllView>(List.OrderBy(item => item.ProduktNazwa));
            if (SortField == "producent")
                List = new ObservableCollection<DyskForAllView>(List.OrderBy(item => item.Producent));
            if (SortField == "rodzaj")
                List = new ObservableCollection<DyskForAllView>(List.OrderBy(item => item.Rodzaj));
            if (SortField == "pojemnosc")
                List = new ObservableCollection<DyskForAllView>(List.OrderBy(item => item.Pojemnosc));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "nazwa", "producent", "rodzaj", "format", "pojemnosc" };
        }
        public override void Find()
        {
            if (FindField == "nazwa")
                List = new ObservableCollection<DyskForAllView>(List.Where(item => item.ProduktNazwa != null && item.ProduktNazwa.StartsWith(FindTextBox)));
            if (FindField == "producent")
                List = new ObservableCollection<DyskForAllView>(List.Where(item => item.Producent != null && item.Producent.StartsWith(FindTextBox)));
            if (FindField == "rodzaj")
                List = new ObservableCollection<DyskForAllView>(List.Where(item => item.Rodzaj != null && item.Rodzaj.StartsWith(FindTextBox)));
            if (FindField == "format")
                List = new ObservableCollection<DyskForAllView>(List.Where(item => item.Format != null && item.Format.StartsWith(FindTextBox)));
            if (FindField == "pojemnosc")
                List = new ObservableCollection<DyskForAllView>(List.Where(item => item.Pojemnosc != null && item.Pojemnosc.ToString().StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DyskForAllView>
                (
                    from dysk in sklepEntities.Dysk
                    select new DyskForAllView
                    {
                        IdDysku = dysk.IdDysku,
                        ProduktNazwa = dysk.Produkt.Nazwa,
                        Producent = dysk.Producent,
                        Rodzaj = dysk.Rodzaj,
                        Format = dysk.Format,
                        Pojemnosc = dysk.Pojemnosc,
                    }
                );
        }
        #endregion
    }
}

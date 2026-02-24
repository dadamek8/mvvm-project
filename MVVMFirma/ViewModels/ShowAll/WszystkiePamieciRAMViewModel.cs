using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels.ShowAll
{
    public class WszystkiePamieciRAMViewModel : WszystkieViewModel<PamieciRAMForAllView>
    {
        #region Constructor
        public WszystkiePamieciRAMViewModel()
            : base("PamieciRAM")
        {
        }
        #endregion
        #region Sort And Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "nazwa", "producent", "laczna pojemnosc", "czestotliwosc pracy", "liczba modulow" };
        }
        public override void Sort()
        {
            if (SortField == "nazwa")
                List = new ObservableCollection<PamieciRAMForAllView>(List.OrderBy(item => item.ProduktNazwa));
            if (SortField == "producent")
                List = new ObservableCollection<PamieciRAMForAllView>(List.OrderBy(item => item.Producent));
            if (SortField == "laczna pojemnosc")
                List = new ObservableCollection<PamieciRAMForAllView>(List.OrderBy(item => item.LacznaPojemnosc));
            if (SortField == "czestotliwosc pracy")
                List = new ObservableCollection<PamieciRAMForAllView>(List.OrderBy(item => item.CzestotliwoscPracy));
            if (SortField == "liczba modulow")
                List = new ObservableCollection<PamieciRAMForAllView>(List.OrderBy(item => item.LiczbaModulow));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "nazwa", "producent", "typ pamieci" };
        }
        public override void Find()
        {
            if (FindField == "nazwa")
                List = new ObservableCollection<PamieciRAMForAllView>(List.Where(item => item.ProduktNazwa != null && item.ProduktNazwa.StartsWith(FindTextBox)));
            if (FindField == "producent")
                List = new ObservableCollection<PamieciRAMForAllView>(List.Where(item => item.Producent != null && item.Producent.StartsWith(FindTextBox)));
            if (FindField == "typ pamieci")
                List = new ObservableCollection<PamieciRAMForAllView>(List.Where(item => item.TypPamieci != null && item.TypPamieci.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PamieciRAMForAllView>
                (
                    from pamiecRAM in sklepEntities.PamiecRAM
                    select new PamieciRAMForAllView
                    {
                        IdPamieciRAM = pamiecRAM.IdPamieciRAM,
                        ProduktNazwa = pamiecRAM.Produkt.Nazwa,
                        Producent = pamiecRAM.Producent,
                        LacznaPojemnosc = pamiecRAM.LacznaPojemnosc,
                        TypPamieci = pamiecRAM.TypPamieci,
                        CzestotliwoscPracy = pamiecRAM.CzestotliwoscPracy,
                        LiczbaModulow = pamiecRAM.LiczbaModulow
                    }
                );
        }
        #endregion
    }
}

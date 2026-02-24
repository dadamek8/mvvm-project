using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels.ShowAll
{
    public class WszystkieKartyGraficzneViewModel : WszystkieViewModel<KartaGraficznaForAllView>
    {
        #region Constructor
        public WszystkieKartyGraficzneViewModel()
            : base("KartyGraficzne")
        {
        }
        #endregion
        #region Sort And Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "nazwa", "producent karty", "producent chipsetu", "RAM", "taktowanie rdzenia" };
        }
        public override void Sort()
        {
            if (SortField == "producent karty")
                List = new ObservableCollection<KartaGraficznaForAllView>(List.OrderBy(item => item.ProducentKarty));
            if (SortField == "nazwa")
                List = new ObservableCollection<KartaGraficznaForAllView>(List.OrderBy(item => item.ProduktNazwa));
            if (SortField == "producent chipsetu")
                List = new ObservableCollection<KartaGraficznaForAllView>(List.OrderBy(item => item.ProducentChipsetu));
            if (SortField == "RAM")
                List = new ObservableCollection<KartaGraficznaForAllView>(List.OrderBy(item => item.RAM));
            if (SortField == "taktowanie rdzenia")
                List = new ObservableCollection<KartaGraficznaForAllView>(List.OrderBy(item => item.TaktowanieRdzenia));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "nazwa", "producent karty", "producent chipsetu", "chipset" };
        }
        public override void Find()
        {
            if (FindField == "nazwa")
                List = new ObservableCollection<KartaGraficznaForAllView>(List.Where(item => item.ProduktNazwa != null && item.ProduktNazwa.StartsWith(FindTextBox)));
            if (FindField == "producent karty")
                List = new ObservableCollection<KartaGraficznaForAllView>(List.Where(item => item.ProducentKarty != null && item.ProducentKarty.StartsWith(FindTextBox)));
            if (FindField == "producent chipsetu")
                List = new ObservableCollection<KartaGraficznaForAllView>(List.Where(item => item.ProducentChipsetu != null && item.ProducentChipsetu.StartsWith(FindTextBox)));
            if (FindField == "chipset")
                List = new ObservableCollection<KartaGraficznaForAllView>(List.Where(item => item.ProducentChipsetu != null && item.ProducentChipsetu.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KartaGraficznaForAllView>
                (
                    from kartaGraficzna in sklepEntities.KartaGraficzna
                    select new KartaGraficznaForAllView
                    {
                        IdKartyGraficznej=kartaGraficzna.IdKartyGraficznej,
                        ProduktNazwa=kartaGraficzna.Produkt.Nazwa,
                        ProducentKarty=kartaGraficzna.ProducentKarty,
                        ProducentChipsetu=kartaGraficzna.ProducentChipsetu,
                        Chipset=kartaGraficzna.Chipset,
                        RAM=kartaGraficzna.RAM,
                        TaktowanieRdzenia=kartaGraficzna.TaktowanieRdzenia

                    }
                );
        }
        #endregion
    }
}

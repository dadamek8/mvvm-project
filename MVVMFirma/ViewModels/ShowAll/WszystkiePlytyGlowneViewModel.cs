using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class WszystkiePlytyGlowneViewModel : WszystkieViewModel<PlytaGlownaForAllView>
    {
        #region Constructor
        public WszystkiePlytyGlowneViewModel()
            : base("PlytyGlowne")
    {
    }
        #endregion
        #region Sort And Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "nazwa", "producent", "sloty pamieci" };
        }
        public override void Sort()
        {
            if (SortField == "nazwa")
                List = new ObservableCollection<PlytaGlownaForAllView>(List.OrderBy(item => item.ProduktNazwa));
            if (SortField == "producent")
                List = new ObservableCollection<PlytaGlownaForAllView>(List.OrderBy(item => item.Producent));
            if (SortField == "sloty pamieci")
                List = new ObservableCollection<PlytaGlownaForAllView>(List.OrderBy(item => item.SlotyPamieci));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "nazwa", "producent", "gniazdo procesora" };
        }
        public override void Find()
        {
            if (FindField == "nazwa")
                List = new ObservableCollection<PlytaGlownaForAllView>(List.Where(item => item.ProduktNazwa != null && item.ProduktNazwa.StartsWith(FindTextBox)));
            if (FindField == "producent")
                List = new ObservableCollection<PlytaGlownaForAllView>(List.Where(item => item.Producent != null && item.Producent.StartsWith(FindTextBox)));
            if (FindField == "gniazdo procesora")
                List = new ObservableCollection<PlytaGlownaForAllView>(List.Where(item => item.GniazdoProcesora != null && item.GniazdoProcesora.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
    {
        List = new ObservableCollection<PlytaGlownaForAllView>
            (
                from plytaGlowna in sklepEntities.PlytaGlowna
                select new PlytaGlownaForAllView
                {
                    IdPlytyGlownej = plytaGlowna.IdPlytyGlownej,
                    ProduktNazwa = plytaGlowna.Produkt.Nazwa,
                    Producent = plytaGlowna.Producent,
                    GniazdoProcesora = plytaGlowna.GniazdoProcesora,
                    SlotyPamieci = plytaGlowna.SlotyPamieci,
                    WiFi = plytaGlowna.WiFi,
                    Bluetooth = plytaGlowna.Bluetooth
                }
            );
    }
    #endregion
}
}

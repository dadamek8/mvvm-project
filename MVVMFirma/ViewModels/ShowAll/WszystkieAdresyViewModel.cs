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
    public class WszystkieAdresyViewModel : WszystkieViewModel<Adres>
    {
        #region Constructor
        public WszystkieAdresyViewModel()
            : base("Adresy")
        {
        }
        #endregion
        #region Sort And Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "miejscowosc", "kod pocztowy", "poczta" };
        }
        public override void Sort()
        {
            if (SortField == "miejscowosc")
                List = new ObservableCollection<Adres>(List.OrderBy(item => item.Miejscowosc));
            if (SortField == "kod pocztowy")
                List = new ObservableCollection<Adres>(List.OrderBy(item => item.KodPocztowy));
            if (SortField == "poczta")
                List = new ObservableCollection<Adres>(List.OrderBy(item => item.Poczta));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "miejscowosc", "ulica", "kod pocztowy", "poczta" };
        }
        public override void Find()
        {
            if (FindField == "miejscowosc")
                List = new ObservableCollection<Adres>(List.Where(item => item.Miejscowosc != null && item.Miejscowosc.StartsWith(FindTextBox)));
            if (FindField == "ulica")
                List = new ObservableCollection<Adres>(List.Where(item => item.Ulica != null && item.Ulica.StartsWith(FindTextBox)));
            if (FindField == "kod pocztowy")
                List = new ObservableCollection<Adres>(List.Where(item => item.KodPocztowy != null && item.KodPocztowy.StartsWith(FindTextBox)));
            if (FindField == "poczta")
                List = new ObservableCollection<Adres>(List.Where(item => item.Poczta != null && item.Poczta.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Adres>
                (
                sklepEntities.Adres.ToList()
                );
        }
        #endregion
    }
}

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
    public class WszystkieFirmyViewModel : WszystkieViewModel<FirmyForAllView>
    {
        #region Constructor
        public WszystkieFirmyViewModel()
            : base("Firmy")
        {
        }
        #endregion
        #region Sort And Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "nazwa", "NIP", "REGON" };
        }
        public override void Sort()
        {
            if (SortField == "nazwa")
                List = new ObservableCollection<FirmyForAllView>(List.OrderBy(item => item.Nazwa));
            if (SortField == "NIP")
                List = new ObservableCollection<FirmyForAllView>(List.OrderBy(item => item.NIP));
            if (SortField == "REGON")
                List = new ObservableCollection<FirmyForAllView>(List.OrderBy(item => item.REGON));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "nazwa", "NIP", "REGON", "e-mail", "telefon" };
        }
        public override void Find()
        {
            if (FindField == "nazwa")
                List = new ObservableCollection<FirmyForAllView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "NIP")
                List = new ObservableCollection<FirmyForAllView>(List.Where(item => item.NIP != null && item.NIP.StartsWith(FindTextBox)));
            if (FindField == "REGON")
                List = new ObservableCollection<FirmyForAllView>(List.Where(item => item.REGON != null && item.REGON.StartsWith(FindTextBox)));
            if (FindField == "e-mail")
                List = new ObservableCollection<FirmyForAllView>(List.Where(item => item.KlientEmail != null && item.KlientEmail.StartsWith(FindTextBox)));
            if (FindField == "telefon")
                List = new ObservableCollection<FirmyForAllView>(List.Where(item => item.KlientTelefon != null && item.KlientTelefon.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<FirmyForAllView>
                (
                    from firma in sklepEntities.Firma
                    select new FirmyForAllView
                    {
                        IdFirmy = firma.IdFirmy,
                        Nazwa = firma.Nazwa,
                        NIP = firma.NIP,
                        REGON = firma.REGON,
                        KlientEmail = firma.Klient.Email,
                        KlientTelefon = firma.Klient.Telefon
                    }
                );
        }
        #endregion
    }
}

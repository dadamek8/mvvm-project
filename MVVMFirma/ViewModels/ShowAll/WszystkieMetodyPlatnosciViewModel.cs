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
    public class WszystkieMetodyPlatnosciViewModel : WszystkieViewModel<MetodaPlatnosci>
    {
        #region Constructor
        public WszystkieMetodyPlatnosciViewModel()
            : base("MetodyPlatnosci")
        {
        }
        #endregion
        #region Sort And Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "nazwa" };
        }
        public override void Sort()
        {
            if (SortField == "nazwa")
                List = new ObservableCollection<MetodaPlatnosci>(List.OrderBy(item => item.Nazwa));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "nazwa" };
        }
        public override void Find()
        {
            if (FindField == "nazwa")
                List = new ObservableCollection<MetodaPlatnosci>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<MetodaPlatnosci>
                (
                sklepEntities.MetodaPlatnosci.ToList()
                );
        }
        #endregion
    }
}

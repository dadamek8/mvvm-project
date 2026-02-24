using GalaSoft.MvvmLight.Messaging;
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
    public class WszystkiePromocjeViewModel : WszystkieViewModel<Promocja>
    {
        #region Constructor
        public WszystkiePromocjeViewModel()
            : base("Promocje")
        {
        }
        #endregion
        #region Properties
        private Promocja _WybranaPromocja;
        public Promocja WybranaPromocja
        {
            get
            {
                return _WybranaPromocja;
            }
            set
            {
                _WybranaPromocja = value;
                Messenger.Default.Send(_WybranaPromocja);
                OnRequestClose();
            }
        }
        #endregion
        #region Sort And Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "nazwa", "data rozpoczecia", "data zakonczenia" };
        }
        public override void Sort()
        {
            if (SortField == "nazwa")
                List = new ObservableCollection<Promocja>(List.OrderBy(item => item.Nazwa));
            if (SortField == "data rozpoczecia")
                List = new ObservableCollection<Promocja>(List.OrderBy(item => item.DataRozpoczecia));
            if (SortField == "data zakonczenia")
                List = new ObservableCollection<Promocja>(List.OrderBy(item => item.DataZakonczenia));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "nazwa" };
        }
        public override void Find()
        {
            if (FindField == "nazwa")
                List = new ObservableCollection<Promocja>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Promocja>
                (
                sklepEntities.Promocja.ToList()
                );
        }
        #endregion
    }
}

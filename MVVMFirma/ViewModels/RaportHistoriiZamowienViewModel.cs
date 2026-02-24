using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
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
    public class RaportHistoriiZamowienViewModel : WorkspaceViewModel
    {
        #region DB
        SklepEntities db;
        HistoriaZamowienB historiaZamowienB;
        #endregion
        #region Constructor
        public RaportHistoriiZamowienViewModel()
        {
            base.DisplayName = "Raport historii zamowien";
            db = new SklepEntities();
            historiaZamowienB = new HistoriaZamowienB(db);
            Zamowienia = new ObservableCollection<HistoriaZamowienForView>();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
        }
        #endregion
        #region Properties
        private int _IdKlienta;
        public int IdKlienta
        {
            get
            {
                return _IdKlienta;
            }
            set
            {
                if (_IdKlienta != value)
                {
                    _IdKlienta = value;
                    OnPropertyChanged(() => IdKlienta);
                }
            }
        }
        private DateTime _DataOd;
        public DateTime DataOd
        {
            get
            {
                return _DataOd;
            }
            set
            {
                if (_DataOd != value)
                {
                    _DataOd = value;
                    OnPropertyChanged(() => DataOd);
                }
            }
        }
        private DateTime _DataDo;
        public DateTime DataDo
        {
            get
            {
                return _DataDo;
            }
            set
            {
                if (_DataDo != value)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }
            }
        }
        public ObservableCollection<HistoriaZamowienForView> Zamowienia { get; set; }
        #endregion
        #region ComboBoxProperties
        public IQueryable<KeyAndValue> KlienciItems
        {
            get
            {
                return new KlienciB(db).GetKlienciKeyAndValueItems();
            }
        }
        #endregion
        #region Commands
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                    _ObliczCommand = new BaseCommand(() => zbierzZamowieniaKlientaClick());
                return _ObliczCommand;
            }
        }
        private void zbierzZamowieniaKlientaClick()
        {
            var zamowienia = historiaZamowienB.GetZamowieniaKlienta(IdKlienta, DataOd, DataDo);
            Zamowienia.Clear();
            foreach (var zamowienie in zamowienia)
            {
                Zamowienia.Add(zamowienie);
            }
        }
        #endregion
    }
}

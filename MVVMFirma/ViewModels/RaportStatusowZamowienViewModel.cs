using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class RaportStatusowZamowienViewModel : WorkspaceViewModel
    {
        #region DB
        SklepEntities db;
        #endregion
        #region Constructor
        public RaportStatusowZamowienViewModel()
        {
            base.DisplayName = "Raport statusow zamowien";
            db = new SklepEntities();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            ZamowieniaZeStatusem = 0;
            WszystkieZamowienia = 0;
        }
        #endregion
        #region Properties
        private int _IdStatusu;
        public int IdStatusu
        {
            get
            {
                return _IdStatusu;
            }
            set
            {
                if (_IdStatusu != value)
                {
                    _IdStatusu = value;
                    OnPropertyChanged(() => IdStatusu);
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
        private int? _ZamowieniaZeStatusem;
        public int? ZamowieniaZeStatusem
        {
            get
            {
                return _ZamowieniaZeStatusem;
            }
            set
            {
                if (_ZamowieniaZeStatusem != value)
                {
                    _ZamowieniaZeStatusem = value;
                    OnPropertyChanged(() => ZamowieniaZeStatusem);
                }
            }
        }
        private int? _WszystkieZamowienia;
        public int? WszystkieZamowienia
        {
            get
            {
                return _WszystkieZamowienia;
            }
            set
            {
                if (_WszystkieZamowienia != value)
                {
                    _WszystkieZamowienia = value;
                    OnPropertyChanged(() => WszystkieZamowienia);
                }
            }
        }
        #endregion
        #region ComboBoxProperties
        public IQueryable<KeyAndValue> StatusyItems
        {
            get
            {
                return new StatusyB(db).GetStatusyKeyAndValueItems();
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
                    _ObliczCommand = new BaseCommand(() => obliczIloscZamowien());
                return _ObliczCommand;
            }
        }
        private void obliczIloscZamowien()
        {
            ZamowieniaZeStatusem = new StatusyZamowienB(db).StatusyZamowienOkres(IdStatusu, DataOd, DataDo);
            WszystkieZamowienia = new StatusyZamowienB(db).IloscZamowienOkres(DataOd, DataDo);
        }
        #endregion
    }
}


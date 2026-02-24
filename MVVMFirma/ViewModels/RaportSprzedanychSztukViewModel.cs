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
    public class RaportSprzedanychSztukViewModel : WorkspaceViewModel
    {
        #region DB
        SklepEntities db;
        #endregion
        #region Constructor
        public RaportSprzedanychSztukViewModel() 
        {
            base.DisplayName = "Raport sprzedanych sztuk";
            db = new SklepEntities();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            SprzedaneSztuki = 0;
        }
        #endregion
        #region Properties
        private int _IdProduktu;
        public int IdProduktu
        {
            get
            {
                return _IdProduktu;
            }
            set
            {
                if (_IdProduktu != value)
                {
                    _IdProduktu = value;
                    OnPropertyChanged(() => IdProduktu);
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
        private int? _SprzedaneSztuki;
        public int? SprzedaneSztuki
        {
            get
            {
                return _SprzedaneSztuki;
            }
            set
            {
                if (_SprzedaneSztuki != value)
                {
                    _SprzedaneSztuki = value;
                    OnPropertyChanged(() => SprzedaneSztuki);
                }
            }
        }
        #endregion
        #region ComboBoxProperties
        public IQueryable<KeyAndValue> ProduktyItems
        {
            get
            {
                return new ProduktyB(db).GetProduktyKeyAndValueItems();
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
                    _ObliczCommand = new BaseCommand(() => policzSprzedaneSztukiClick());
                return _ObliczCommand;
            }
        }
        private void policzSprzedaneSztukiClick()
        {
            SprzedaneSztuki = new SprzedaneSztukiB(db).SprzedaneSztukiOkres(IdProduktu, DataOd, DataDo);
        }
        #endregion
    }
}

using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {
        #region DB
        protected SklepEntities sklepEntities;
        #endregion
        #region Item
        protected T item;
        #endregion
        #region Command
        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                return _SaveCommand;
            }
        }
        #endregion
        #region Constructor
        public JedenViewModel(string displayName)
        {
            base.DisplayName = displayName;
            sklepEntities = new SklepEntities();
        }
        #endregion
        #region Helpers
        public abstract void Save();
        public void SaveAndClose()
        {
            if (isValid())
            {
                Save();
                base.OnRequestClose();
            }
        }
        #endregion
        #region Validation
        public virtual bool isValid()
        {
            return true;
        }
        #endregion

    }
}

using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowyStatusViewModel : JedenViewModel<Status>
    {
        #region Constructor
        public NowyStatusViewModel()
            : base("Status")
        {
            item = new Status();
        }
        #endregion
        #region Properties
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                item.Nazwa = value;
                OnPropertyChanged(() => Nazwa);
            }
        }
        public string Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                item.Opis = value;
                OnPropertyChanged(() => Opis);
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            sklepEntities.Status.Add(item);
            sklepEntities.SaveChanges();
        }
        #endregion
    }
}

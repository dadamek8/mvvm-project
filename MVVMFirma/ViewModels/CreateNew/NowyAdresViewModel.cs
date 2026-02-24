using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowyAdresViewModel : JedenViewModel<Adres>
    {
        #region Constructor
        public NowyAdresViewModel()
            : base("Adres")
        {
            item = new Adres();
        }
        #endregion
        #region Properties
        public string Miejscowosc
        {
            get
            {
                return item.Miejscowosc;
            }
            set
            {
                item.Miejscowosc = value;
                OnPropertyChanged(() => Miejscowosc);
            }
        }
        public string Ulica
        {
            get
            {
                return item.Ulica;
            }
            set
            {
                item.Ulica = value;
                OnPropertyChanged(() => Ulica);
            }
        }
        public string NrDomu
        {
            get
            {
                return item.NrDomu;
            }
            set
            {
                item.NrDomu = value;
                OnPropertyChanged(() => NrDomu);
            }
        }
        public string NrLokalu
        {
            get
            {
                return item.NrLokalu;
            }
            set
            {
                item.NrLokalu = value;
                OnPropertyChanged(() => NrLokalu);
            }
        }
        public string KodPocztowy
        {
            get
            {
                return item.KodPocztowy;
            }
            set
            {
                item.KodPocztowy = value;
                OnPropertyChanged(() => KodPocztowy);
            }
        }
        public string Poczta
        {
            get
            {
                return item.Poczta;
            }
            set
            {
                item.Poczta = value;
                OnPropertyChanged(() => Poczta);
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            sklepEntities.Adres.Add(item);
            sklepEntities.SaveChanges();
        }
        #endregion
    }
}

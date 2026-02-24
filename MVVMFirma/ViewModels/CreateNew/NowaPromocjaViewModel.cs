using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowaPromocjaViewModel : JedenViewModel<Promocja>
    {
        #region Constructor
        public NowaPromocjaViewModel()
            : base("Promocja")
        {
            item = new Promocja();
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
        public bool? CzyAktywna
        {
            get
            {
                return item.CzyAktywna;
            }
            set
            {
                item.CzyAktywna = value;
                OnPropertyChanged(() => CzyAktywna);
            }
        }
        public DateTime? DataRozpoczecia
        {
            get
            {
                return item.DataRozpoczecia;
            }
            set
            {
                item.DataRozpoczecia = value;
                OnPropertyChanged(() => DataRozpoczecia);
            }
        }
        public DateTime? DataZakonczenia
        {
            get
            {
                return item.DataZakonczenia;
            }
            set
            {
                item.DataZakonczenia = value;
                OnPropertyChanged(() => DataZakonczenia);
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            sklepEntities.Promocja.Add(item);
            sklepEntities.SaveChanges();
        }
        #endregion
    }
}

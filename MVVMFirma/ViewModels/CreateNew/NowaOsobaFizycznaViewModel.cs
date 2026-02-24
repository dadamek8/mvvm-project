using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Models.Validatory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowaOsobaFizycznaViewModel: JedenViewModel<OsobaFizyczna>, IDataErrorInfo
    {
        #region Constructor
        public NowaOsobaFizycznaViewModel()
            : base("OsobaFizyczna")
        {
            item = new OsobaFizyczna();
            Messenger.Default.Register<KlientForAllView>(this, getWybranyKlient);
        }
        #endregion
        #region Properties
        public int? IdKlienta
        {
            get
            {
                return item.IdKlienta;
            }
            set
            {
                item.IdKlienta = value;
                OnPropertyChanged(() => IdKlienta);
            }
        }
        public string KlientEmail { get; set; }
        public string Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                item.Imie = value;
                OnPropertyChanged(() => Imie);
            }
        }
        public string Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                item.Nazwisko = value;
                OnPropertyChanged(() => Nazwisko);
            }
        }
        #endregion
        #region ComboBoxProperties
        public IQueryable<KeyAndValue> KlienciItems
        {
            get
            {
                return new KlienciB(sklepEntities).GetKlienciKeyAndValueItems();
            }
        }
        #endregion
        #region Commands
        private BaseCommand _ShowKlienci;
        public ICommand ShowKlienci
        {
            get
            {
                if (_ShowKlienci == null)
                    _ShowKlienci = new BaseCommand(() => showKlienci());
                return _ShowKlienci;
            }
        }
        private void showKlienci()
        {
            Messenger.Default.Send<string>("KlienciAll");
        }
        #endregion
        #region Helpers
        private void getWybranyKlient(KlientForAllView klient)
        {
            IdKlienta = klient.IdKlienta;
            KlientEmail = klient.Email;
        }
        public override void Save()
        {
            sklepEntities.OsobaFizyczna.Add(item);
            sklepEntities.SaveChanges();
        }
        #endregion
        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Imie")
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Imie);
                if (name == "Nazwisko")
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Nazwisko);
                return komunikat;
            }
        }
        public override bool isValid()
        {
            if (this["Imie"] == null && this["Nazwisko"] == null)
                return true;
            return false;
        }
        #endregion

    }
}

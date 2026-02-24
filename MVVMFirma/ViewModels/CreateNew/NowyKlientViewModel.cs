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

namespace MVVMFirma.ViewModels
{
    public class NowyKlientViewModel : JedenViewModel<Klient>, IDataErrorInfo
    {
        #region Constructor
        public NowyKlientViewModel()
            : base("Klient")
        {
            item = new Klient();
        }
        #endregion
        #region Properties
        public string RodzajKlienta
        {
            get
            {
                return item.RodzajKlienta;
            }
            set
            {
                item.RodzajKlienta = value;
                OnPropertyChanged(() => RodzajKlienta);
            }
        }
        public string Email
        {
            get
            {
                return item.Email;
            }
            set
            {
                item.Email = value;
                OnPropertyChanged(() => Email);
            }
        }
        public string Telefon
        {
            get
            {
                return item.Telefon;
            }
            set
            {
                item.Telefon = value;
                OnPropertyChanged(() => Telefon);
            }
        }
        public int? IdAdresu
        {
            get
            {
                return item.IdAdresu;
            }
            set
            {
                item.IdAdresu = value;
                OnPropertyChanged(() => IdAdresu);
            }
        }
        public DateTime? DataRejestracji
        {
            get
            {
                return item.DataRejestracji;
            }
            set
            {
                item.DataRejestracji = value;
                OnPropertyChanged(() => DataRejestracji);
            }
        }
        #endregion
        #region ComboBoxProperties
        public IQueryable<KeyAndValue> AdresyItems
        {
            get
            {
                return new AdresyB(sklepEntities).GetAdresyKeyAndValueItems();
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            sklepEntities.Klient.Add(item);
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
                if (name == "Telefon")
                    komunikat = StringValidator.SprawdzNumerTelefonu(this.Telefon);
                if (name == "DataRejestracji")
                    komunikat = BiznesValidator.SprawdzDateRejestracji(this.DataRejestracji);
                return komunikat;
            }
        }
        public override bool isValid()
        {
            if (this["Telefon"] == null && this["DataRejestracji"] == null)
                return true;
            return false;
        }
        #endregion

    }
}

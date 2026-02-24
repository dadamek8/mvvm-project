using GalaSoft.MvvmLight.Messaging;
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
    public class NowaFirmaViewModel : JedenViewModel<Firma>
    {
        #region Constructor
        public NowaFirmaViewModel()
            : base("Firma")
        {
            item = new Firma();
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
        public string NIP
        {
            get
            {
                return item.NIP;
            }
            set
            {
                item.NIP = value;
                OnPropertyChanged(() => NIP);
            }
        }
        public string REGON
        {
            get
            {
                return item.REGON;
            }
            set
            {
                item.REGON = value;
                OnPropertyChanged(() => REGON);
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
            sklepEntities.Firma.Add(item);
            sklepEntities.SaveChanges();
        }
        #endregion
    }
}

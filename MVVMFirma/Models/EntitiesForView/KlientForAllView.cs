using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class KlientForAllView
    {
        public int IdKlienta { get; set; }
        public string RodzajKlienta { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string AdresMiejscowosc { get; set; }
        public string AdresUlica { get; set; }
        public string AdresNrDomu { get; set; }
        public string AdresNrLokalu { get; set; }
        public string AdresKodPocztowy { get; set; }
        public string AdresPoczta { get; set; }
        public DateTime? DataRejestracji { get; set; }
    }
}

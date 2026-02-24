using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PracownikForAllView
    {
        public int IdPracownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Stanowisko { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string AdresMiejscowosc { get; set; }
        public string AdresUlica { get; set; }
        public string AdresNrDomu { get; set; }
        public string AdresNrLokalu { get; set; }
        public string AdresKodPocztowy { get; set; }
        public string AdresPoczta { get; set; }
    }
}

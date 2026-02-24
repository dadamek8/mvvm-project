using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class DyskForAllView
    {
        public int IdDysku { get; set; }
        public string ProduktNazwa {  get; set; }
        public string Producent { get; set; }
        public string Rodzaj { get; set; }
        public string Format { get; set; }
        public int? Pojemnosc { get; set; }
    }
}

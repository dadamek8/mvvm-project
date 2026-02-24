using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class ProcesorForAllView
    {
        public int IdProcesora { get; set; }
        public string ProduktNazwa { get; set; }
        public string Producent { get; set; }
        public int? LiczbaRdzeni { get; set; }
        public int? LiczbaWatkow { get; set; }
        public decimal? Taktowanie { get; set; }
        public string TypGniazda { get; set; }
    }
}

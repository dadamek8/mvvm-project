using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PamieciRAMForAllView
    {
        public int IdPamieciRAM { get; set; }
        public string ProduktNazwa { get; set; }
        public string Producent { get; set; }
        public int? LacznaPojemnosc { get; set; }
        public string TypPamieci { get; set; }
        public string CzestotliwoscPracy { get; set; }
        public int? LiczbaModulow { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class KartaGraficznaForAllView
    {
        public int IdKartyGraficznej { get; set; }
        public string ProduktNazwa { get; set; }
        public string ProducentKarty { get; set; }
        public string ProducentChipsetu { get; set; }
        public string Chipset { get; set; }
        public int? RAM { get; set; }
        public int? TaktowanieRdzenia { get; set; }
    }
}

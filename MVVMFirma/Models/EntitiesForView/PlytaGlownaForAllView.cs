using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PlytaGlownaForAllView
    {
        public int IdPlytyGlownej { get; set; }
        public string ProduktNazwa { get; set; }
        public string Producent { get; set; }
        public string GniazdoProcesora { get; set; }
        public int? SlotyPamieci { get; set; }
        public bool? WiFi { get; set; }
        public bool? Bluetooth { get; set; }
    }
}

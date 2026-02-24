using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class ZamowienieForAllView
    {
        public int IdZamowienia { get; set; }
        public string KlientEmail { get; set; }
        public string MetodaPlatnosciNazwa { get; set; }
        public DateTime? DataZlozenia { get; set; }
        public string StatusNazwa { get; set; }
        public decimal? KwotaZamowienia { get; set; }
    }
}

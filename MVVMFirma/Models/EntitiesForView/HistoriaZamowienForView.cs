using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class HistoriaZamowienForView
    {
        public int IdZamowienia { get; set; }
        public decimal? KwotaZamowienia { get; set; }
        public string MetodaPlatnosci { get; set; }
        public DateTime? DataZlozenia { get; set; }
        public string Status { get; set; }
    }
}

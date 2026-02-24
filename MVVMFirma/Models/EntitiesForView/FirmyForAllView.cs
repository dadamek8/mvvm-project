using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class FirmyForAllView
    {
        public int IdFirmy { get; set; }
        public string KlientEmail { get; set; }
        public string KlientTelefon { get; set; }
        public string Nazwa { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
    }
}

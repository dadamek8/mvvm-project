using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PozycjaZamowieniaForAllView
    {
        public int IdPozycjiZamowienia { get; set; }
        public string ZamowienieId { get; set; }
        public string PromocjaNazwa { get; set; }
        public string ProduktNazwa { get; set; }
        public int? Ilosc { get; set; }
        public decimal? CenaCalkowita { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Validatory
{
    internal class BiznesValidator : Validator
    {
        public static string SprawdzIloscOrazCene(decimal? wartosc)
        {
            try
            {
                if (wartosc < 0)
                {
                    return "Wpisz liczbę dodatnią";
                }
            }
            catch (Exception)
            { };
            return null;
        }
        public static string SprawdzDateRejestracji(DateTime? dataRejestracji)
        {
            try
            {
                if (dataRejestracji > DateTime.Now)
                {
                    return "Data rejestracji nie może być późniejsza niż aktualna data";
                }
            }
            catch (Exception)
            { };
            return null;
        }
    }
}

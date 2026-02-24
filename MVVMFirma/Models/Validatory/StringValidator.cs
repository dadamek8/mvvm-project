using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Validatory
{
    public class StringValidator:Validator
{
    public static string SprawdzCzyZaczynaSieOdDuzej(string wartosc)
    {
        try
        {
            if (!char.IsUpper(wartosc, 0))
            {
                return "Rozpocznij dużą literą";
            }
        }
        catch (Exception)
        { };
        return null;
    }
        public static string SprawdzNumerTelefonu(string numer)
        {
            try
            {
                if (!Regex.IsMatch(numer, @"^\+?\d+$"))
                {
                    return "Numer telefonu jest niepoprawny";
                }
            }
            catch (Exception)
            { };
            return null;
        }
    }
}

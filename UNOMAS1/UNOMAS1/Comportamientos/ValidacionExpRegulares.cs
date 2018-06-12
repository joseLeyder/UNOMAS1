using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace UNOMAS1.Comportamientos
{
    class ValidacionExpRegulares
    {
        public bool IsValidAlphaNumeric(string texto)
        {
            try
            {
                return Regex.IsMatch(texto, @"^[a-z0-9ü][a-z0-9ü_]{3,35}$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsValidEmail(string texto)
        {
            try
            {
                string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
                return Regex.IsMatch(texto, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsValidNombrePropio(string texto)
        {
            try
            {
                string NameRegex = @"^([A-ZÁÉÍÓÚ]{1}[a-zñáéíóú]+[\s]*)+$";
                return Regex.IsMatch(texto, NameRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsValidOnlyLetters(string texto)
        {
            try
            {
                string OnlylettersRegex = @"^[A-Za-z]+$";
                return Regex.IsMatch(texto, OnlylettersRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsValidOnlyNumbers(string texto)
        {
            try
            {
                string OnlyNumbersRegex = @"^[0-9]*$";
                return Regex.IsMatch(texto, OnlyNumbersRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsValidPhoneNumber(string texto)
        {
            try
            {
                //1234567890 ó 961-255-6800 ó 961 255 6800
                string PhoneNumber = @"^\d{3}[- ]?\d{3}[- ]?\d{4}$";
                return Regex.IsMatch(texto, PhoneNumber, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

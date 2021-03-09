using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using HCIProjekat.Modeli;

namespace HCIProjekat.Validacije
{
    public class ValidacijaComboBox : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string err = "*".PadLeft(1);
            string err2 = "!".PadLeft(1);
            try
            {
                var s = value as string;
                double r;
                if (String.IsNullOrWhiteSpace(s))
                {
                    return new ValidationResult(false, err);
                }
                if (double.TryParse(s, out r))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, err2);
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProyectoEstudiantes.Resources.ValidationsRules
{
    public class MyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value is string)
            {
                string valor = (string)value;

                try
                {
                    int edad = int.Parse(valor);

                    if (edad < 0)
                    {
                        return new ValidationResult(false, "La edad no puede ser negativa");
                    }

                    
                    
                }
                catch
                {
                    Console.WriteLine("No es entero");
                    return new ValidationResult(false, "Sólo números!!!");
                }

                
            }
            
            if(value is DateTime)
            {
                if (value != null)
                {
                    DateTime fechaSeleccionada = (DateTime)value;
                    if (fechaSeleccionada > DateTime.Now)
                    {
                        return new ValidationResult(false, "La fecha no puede ser superior a hoy");
                    }
                }
                else
                {
                    return new ValidationResult(false, "Escribe una fecha");
                }
            }

            

            return new ValidationResult(true, null);
        }
    }
}

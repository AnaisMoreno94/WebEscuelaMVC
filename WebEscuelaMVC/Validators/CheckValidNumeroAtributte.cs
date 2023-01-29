using System.ComponentModel.DataAnnotations;

namespace WebEscuelaMVC.Validators
{
    public class CheckValidNumeroAtributte : ValidationAttribute
    {
        public CheckValidNumeroAtributte() 
        {
            ErrorMessage = "El Número debe ser mayor a 100";
        }
        public override bool IsValid(object value)
        {
            int numero = (int)value;
            if (numero > 100) return true; else return false;
        }
    }
}

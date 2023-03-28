using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Contacts.Models.Validators
{
    //class implementing validator for password, used when password is being created
    class PasswordValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string pass = value.ToString();
            var specialRegrex = new Regex(".*[-+_!@#$%^&*.,?].*");
            var smallLetters = new Regex(".*[a-z].*");
            var bigLetters = new Regex(".*[A-Z].*");
            var digits = new Regex(".*[0-9].*");

            if ((specialRegrex.IsMatch(pass) || digits.IsMatch(pass)) && pass.Length >= 8 && smallLetters.IsMatch(pass) && bigLetters.IsMatch(pass))
            {
                return null;
            }
            return new ValidationResult("Hasło musi składać się z co najmniej 8 znaków, zawierać wielką i małą literę oraz cyfrę bądź znak specjalny", 
                new[] { validationContext.MemberName });
        }
    }
}

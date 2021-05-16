using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TournamentApp.Services.Dtos
{
    public class UserRegisterDto : IValidatableObject
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Regex emailRegex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            if (Email != null &&!emailRegex.IsMatch(Email))
            {
                yield return new ValidationResult("Email is not correct, please sumbit a correct email");
            }

            if (Username != null && Username.Length >= 0 && Username.Length >= 200)
            {
                yield return new ValidationResult("The username schould be between 1 and 200 characters");
            }

            Regex passwordRegex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            if (Password != null && !passwordRegex.IsMatch(Password))
            {
                yield return new ValidationResult(
                    "The password should contain least 1 Uppercase character, 1 lowercase character, 1 digit1 1 special character & with a minimum length of 8");

            }
        }
    }
}
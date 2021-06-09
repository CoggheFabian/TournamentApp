using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TournamentApp.Services.Dtos
{
    public class UserRegisterDto : DtoBase
    {
        [Required]
        public string Username { get; set; }

        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        [Required]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "The password should contain least 1 Uppercase character, 1 lowercase character, 1 digit1 1 special character & with a minimum length of 8")]
        public string Password { get; set; }
    }
}
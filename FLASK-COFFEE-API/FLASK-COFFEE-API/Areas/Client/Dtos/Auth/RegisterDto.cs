﻿using System.ComponentModel.DataAnnotations;

namespace FLASK_COFFEE_API.Areas.Client.Dtos.Auth
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = default!;

        [Required(ErrorMessage = "Password is required")]
        [Compare(nameof(Password), ErrorMessage = "Password and confirm password is not same")]
        public string ConfirmPassword { get; set; } = default!;

        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}

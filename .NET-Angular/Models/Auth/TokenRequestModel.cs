﻿using System.ComponentModel.DataAnnotations;

namespace NETAngular.Models.Auth
{
    public class TokenRequestModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

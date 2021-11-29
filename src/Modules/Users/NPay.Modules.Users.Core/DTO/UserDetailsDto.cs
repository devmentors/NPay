﻿using System.ComponentModel.DataAnnotations;

namespace NPay.Modules.Users.Core.DTO
{
    public class UserDetailsDto : UserDto
    {
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string Identity { get; set; }
    }
}
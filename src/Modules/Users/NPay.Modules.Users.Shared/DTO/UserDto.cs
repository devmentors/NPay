using System;
using System.ComponentModel.DataAnnotations;

namespace NPay.Modules.Users.Shared.DTO;

public class UserDto
{
    public Guid UserId { get; set; }
        
    [Required]
    [EmailAddress]
    public string Email { get; set; }
        
    [Required]
    public string FullName { get; set; }
        
    [Required]
    public string Nationality { get; set; }
        
    public string State { get; set; }
    public DateTime CreatedAt { get; set; }
}
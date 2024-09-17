using System;
using System.ComponentModel.DataAnnotations;

namespace NetWPFAreasApp.Models
{
    public class User
    {
        [Key]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

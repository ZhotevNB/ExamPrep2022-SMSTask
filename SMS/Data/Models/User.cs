using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Data.Models
{
    public class User
    {
        [Key]
        [StringLength(DataConstants.GuidMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DataConstants.UserMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(DataConstants.UserPasswordHashMaxLength)]
        public string Password { get; set; }

        [Required]
        [StringLength(DataConstants.GuidMaxLength)]
        public string CardId { get; set; }

        [ForeignKey(nameof(CardId))]
        public Card Card { get; set; } 
    }
}

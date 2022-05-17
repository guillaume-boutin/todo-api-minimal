using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Account
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
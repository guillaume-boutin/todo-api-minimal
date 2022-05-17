using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Upload
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
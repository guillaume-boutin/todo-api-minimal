using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Todo
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        public string? Name { get; set; }

        public bool IsComplete { get; set; }
    }
}
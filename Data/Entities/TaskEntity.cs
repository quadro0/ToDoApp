using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class TaskEntity : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserEntity? User { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public CategoryEntity? Category { get; set; }
    }
}

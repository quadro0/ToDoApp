using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class TaskUpdateRequest
    {
        public Guid Id { get; set; }
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
    }
}

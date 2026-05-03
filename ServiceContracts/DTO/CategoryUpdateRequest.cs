using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class CategoryUpdateRequest
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
        public Guid UserId { get; set; }
    }
}

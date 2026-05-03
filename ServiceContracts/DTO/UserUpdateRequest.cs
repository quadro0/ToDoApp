using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class UserUpdateRequest
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string? Password { get; set; }
    }
}

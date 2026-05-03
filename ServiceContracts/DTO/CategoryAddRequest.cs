using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class CategoryAddRequest
    {
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
    }
}

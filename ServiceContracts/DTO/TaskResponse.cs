namespace ServiceContracts.DTO
{
    public class TaskResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryResponse? Category { get; set; }
    }
}

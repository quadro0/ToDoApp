namespace ServiceContracts.DTO
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public List<TaskResponse>? Tasks { get; set; }
    }
}

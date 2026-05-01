namespace Data.Models
{
    public class TasksPaginationParameters
    {
        public string? SearchName { get; set; }
        public Guid? CategoryId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}

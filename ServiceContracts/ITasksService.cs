using Data.Models;
using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface ITasksService
    {
        Task Add(TaskAddRequest taskAddRequest);
        Task<TaskResponse> GetById(Guid id);
        Task<List<TaskResponse>> GetTasks(Guid userId, TasksPaginationParameters parameters);
        Task<TaskResponse> Update(TaskUpdateRequest taskUpdateRequest);
        Task Delete(Guid id);
    }
}

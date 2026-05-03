using AutoMapper;
using Data.Models;
using Data.Repositories.Interfaces;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class TasksService(IUnitOfWork unitOfWork, IMapper mapper) : ITasksService
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
        private readonly IMapper mapper = mapper;

        public Task Add(TaskAddRequest taskAddRequest)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TaskResponse>> GetTasks(Guid userId, TasksPaginationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<TaskResponse> Update(TaskUpdateRequest taskUpdateRequest)
        {
            throw new NotImplementedException();
        }
    }
}

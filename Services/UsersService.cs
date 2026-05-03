using AutoMapper;
using Data.Repositories.Interfaces;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class UsersService(IUnitOfWork unitOfWork, IMapper mapper) : IUsersService
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
        private readonly IMapper mapper = mapper;

        public Task DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task Register(UserAddRequest userAddRequest)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse> Update(UserUpdateRequest userUpdateRequest)
        {
            throw new NotImplementedException();
        }
    }
}

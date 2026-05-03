using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IUsersService
    {
        Task Register(UserAddRequest userAddRequest);
        Task<UserResponse> Login(string email, string password);
        Task<UserResponse> Update(UserUpdateRequest userUpdateRequest);
        Task DeleteUser(Guid id);
    }
}

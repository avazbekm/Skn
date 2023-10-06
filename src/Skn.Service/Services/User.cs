using Skn.DataAccess.IRepositories;
using Skn.Domain.Configurations;
using Skn.Service.DTOs.Users;
using Skn.Service.Interfaces;

namespace Skn.Service.Services;

public class User : IUser
{
    private readonly IRepository<User> repository;
    public ValueTask<UserResultDto> AddAsync(UserCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserResultDto> MydifyAsync(UserUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<UserCreationDto>> RetrieveAllAsync(PaginationParams @params, string search = null)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}

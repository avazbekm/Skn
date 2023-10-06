using AutoMapper;
using Skn.Domain.Entities;
using Skn.Service.DTOs.Users;
using Skn.Service.Interfaces;
using Skn.Domain.Configurations;
using Skn.DataAccess.IRepositories;

namespace Skn.Service.Services;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IRepository<User> repository;

    public UserService(IMapper mapper, IRepository<User> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

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

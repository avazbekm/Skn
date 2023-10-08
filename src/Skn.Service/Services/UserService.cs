using AutoMapper;
using Skn.Domain.Entities;
using Skn.Service.DTOs.Users;
using Skn.Service.Exceptions;
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

    public async ValueTask<UserResultDto> AddAsync(UserCreationDto dto)
    {
        var user = await this.repository.SelectAsync(u => u.FirstName.Equals(dto.FirstName));
        if (user is not null)
            throw new AlreadyExistException("This User is already exist");

        var mappedUser = this.mapper.Map<User>(dto);
        var mapUser = this.mapper.Map<UserResultDto>(mappedUser);
        await this.repository.SaveAsync();

        return mapUser;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var user = await this.repository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new NotFoundException("This User is not found");

        this.repository.Delete(user);
        await this.repository.SaveAsync();
        return true;
    }

    public async ValueTask<UserResultDto> MydifyAsync(UserUpdateDto dto)
    {
        var user = await this.repository.SelectAsync(u => u.Id.Equals(dto.Id))
            ?? throw new NotFoundException("This User is not found");

        var mapUser = this.mapper.Map(dto, user);
        this.repository.Update(mapUser);
        await this.repository.SaveAsync();

        return this.mapper.Map<UserResultDto>(mapUser);
    }

    public async ValueTask<UserResultDto> RetrieveByIdAsync(long id)
    {
        var user = await this.repository.SelectAsync(u=>u.Id.Equals(id))
            ?? throw new NotFoundException("This User is not found");

        return this.mapper.Map<UserResultDto>(user);
    }
    public async ValueTask<IEnumerable<UserCreationDto>> RetrieveAllAsync(PaginationParams @params, string search = null)
    {
        var users = await this.repository.SelectAll(includes: new[] { "SimCard" })
            .ToPaginate(@params)
            .ToListAsync();

        if (!string.IsNullOrEmpty(search))
            users = users.Where(user => user.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

        return this.mapper.Map<IEnumerable<UserResultDto>>(users);

    }
}

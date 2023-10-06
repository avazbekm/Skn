using Skn.Domain.Configurations;
using Skn.Service.DTOs.Users;

namespace Skn.Service.Interfaces;

public interface IUser
{
    ValueTask<UserResultDto> AddAsync(UserCreationDto dto);
    ValueTask<UserResultDto> MydifyAsync(UserUpdateDto dto);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<UserResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<UserCreationDto>> RetrieveAllAsync(PaginationParams @params, string search = null);
}

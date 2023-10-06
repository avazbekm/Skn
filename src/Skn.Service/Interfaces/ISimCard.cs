using Skn.Domain.Configurations;
using Skn.Service.DTOs.SimCards;

namespace Skn.Service.Interfaces;

public interface ISimCard
{
    ValueTask<SimCardResultDto> AddAsync(SimCardCreationDto dto);
    ValueTask<SimCardResultDto> MydifyAsync(SimCardUpdateDto dto);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<SimCardResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<SimCardCreationDto>> RetrieveAllAsync(PaginationParams @params, string search = null);
}

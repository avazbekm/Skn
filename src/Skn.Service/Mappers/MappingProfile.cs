using AutoMapper;
using Skn.Domain.Entities;
using Skn.Service.DTOs.SimCards;
using Skn.Service.DTOs.Users;

namespace Skn.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // user dto
        CreateMap<UserResultDto,User>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();
        CreateMap<User, UserCreationDto>().ReverseMap();

        // simcard dto
        CreateMap<SimCardResultDto, SimCard>().ReverseMap();
        CreateMap<SimCard, SimCardUpdateDto>().ReverseMap();
        CreateMap<SimCard, SimCardCreationDto>().ReverseMap();
    }
}

using AutoMapper;
using Msharp.Domain.Dto;
using Msharp.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Factory, FactoryDto>()
        .ForMember(x => x.Type, des => des.MapFrom(x => x.FactoryType));

        CreateMap<Employee, EmployeeDto>();

    }
}

using AutoMapper;
using Domain.Entities;

namespace Application.Features.DependentsFeatures.GetAll;

public sealed class GetAllDependentsMapper : Profile
{
    public GetAllDependentsMapper()
    {
        CreateMap<GetAllDependentsRequest, Dependent>();
        CreateMap<Dependent, DependentItem>()
            .ForMember(dest => dest.Relationship, opt => opt.MapFrom(src => src.Relationship))
            .ForMember(dest => dest.RelationshipEnglish, opt => opt.MapFrom(src => src.RelationshipEnglish));
        CreateMap<IEnumerable<Dependent>, GetAllDependentsResponse>()
            .ForMember(dest => dest.Dependents, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.Count()));
    }
}

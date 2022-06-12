using AutoMapper;
using Sit.App.Core.Models;
using Sit.Core.Document;

namespace Sit.App.Core.MappingProfiles;

public class AppToBusinessProfile : Profile
{
    public AppToBusinessProfile()
    {
        CreateMap<InspectionRequest, InspectionRequestDetail>();
    }
}
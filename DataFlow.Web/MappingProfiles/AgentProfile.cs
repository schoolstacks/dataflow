using AutoMapper;
using DataFlow.Models;
using DataFlow.Web.Models;

namespace DataFlow.Web.MappingProfiles
{
    public class AgentProfile : Profile
    {
        public AgentProfile()
        {
            CreateMap<Agent, AgentViewModel>()
                .ForMember(x => x.FormResult, y => y.Ignore());

        }
    }
}
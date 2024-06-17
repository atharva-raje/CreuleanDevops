using AutoMapper;
using BusinessLOgic.Models;
using DAL.Entites;

namespace WebApplication1
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<WorkItem, WorkItemModel>();
            CreateMap<WorkItemModel, WorkItem>();

        }
    }
}

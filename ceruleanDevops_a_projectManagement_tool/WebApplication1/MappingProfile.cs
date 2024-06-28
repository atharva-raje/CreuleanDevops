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
            CreateMap<WorkItem, WorkItemModelWIthId>();
            CreateMap<WorkItemModelWIthId, WorkItem>();
            CreateMap<Status,StatusModelWithoutId>();
            CreateMap<StatusModelWithoutId, Status>();
            CreateMap<AreaWithoutId, Areas>();
            CreateMap<Areas,AreaWithoutId>();
            CreateMap<IterationWIthoutId, Iterations>();
            CreateMap<Iterations, IterationWIthoutId>();
            CreateMap<StatusModelWithoutId, Status>();
            CreateMap<Status,StatusModelWithoutId>();
            CreateMap<User,UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<CommentModel, Comments>();
            CreateMap<Comments,CommentModel>();


        }
    }
}

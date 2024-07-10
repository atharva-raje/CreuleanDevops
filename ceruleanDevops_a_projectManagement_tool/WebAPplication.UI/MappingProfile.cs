using AutoMapper;
using BusinessLOgic.Models;
using System.Runtime.InteropServices;
using WebAPplication.UI.UiModels;

namespace WebAPplication.UI
{
    public class MappingProfile : Profile
    {
         public MappingProfile() 
        {
            CreateMap<UIWorkItem, WorkItemModel>();
            CreateMap<WorkItemModel, UIWorkItem>();

        }

    }
}

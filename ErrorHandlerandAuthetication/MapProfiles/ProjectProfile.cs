using AutoMapper;
using ErrorHandlerandAuthetication.Models;
using ErrorHandlerandAuthetication.ProjModels;

namespace ErrorHandlerandAuthetication.MapProfiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap(); 
        }
    }
}

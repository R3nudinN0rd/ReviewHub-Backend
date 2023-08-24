using AutoMapper;

namespace ReviewHub.Profiles
{
    public class RoleMapping:Profile
    {
        public RoleMapping()
        {
            CreateMap<Entities.Role, Models.RoleModel>().ReverseMap();
        }
    }
}

using AutoMapper;
using ReviewHub.Models;

namespace ReviewHub.Profiles
{
    public class UserMapping:Profile
    {
        public UserMapping()
        {
            CreateMap<Entities.User, UserModel>().ReverseMap();
        }
    }
}

using AutoMapper;
using ReviewHub.Models;

namespace ReviewHub.Profiles
{
    public class EntityTypeMapping:Profile
    {
        public EntityTypeMapping()
        {
            CreateMap<Entities.EntityType, EntityTypeModel>().ReverseMap();
        }
    }
}

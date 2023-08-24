using AutoMapper;
using ReviewHub.Models;

namespace ReviewHub.Profiles
{
    public class ReviewMapping:Profile
    {
        public ReviewMapping()
        {
            CreateMap<Entities.Review, ReviewModel>().ReverseMap();
        }
    }
}

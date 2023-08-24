using AutoMapper;
using ReviewHub.Models;

namespace ReviewHub.Profiles
{
    public class RankMapping:Profile
    {
        public RankMapping()
        {
                CreateMap<Entities.Rank, RankModel>().ReverseMap();
        }
    }
}

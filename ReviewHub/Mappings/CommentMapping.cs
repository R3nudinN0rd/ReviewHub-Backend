using AutoMapper;
using ReviewHub.Models;

namespace ReviewHub.Profiles
{
    public class CommentMapping:Profile
    {
        public CommentMapping()
        {
            CreateMap<Entities.Comment, CommentModel>().ReverseMap();
        }
    }
}

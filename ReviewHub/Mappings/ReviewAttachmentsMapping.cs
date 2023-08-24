using AutoMapper;
using ReviewHub.Models;

namespace ReviewHub.Profiles
{
    public class ReviewAttachmentsMapping:Profile
    {
        public ReviewAttachmentsMapping()
        {
            CreateMap<Entities.ReviewAttachments, ReviewAttachmentsModel>().ReverseMap();
        }
    }
}

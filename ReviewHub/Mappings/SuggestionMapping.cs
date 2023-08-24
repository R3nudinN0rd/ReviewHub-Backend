using AutoMapper;

namespace ReviewHub.Profiles
{
    public class SuggestionMapping:Profile
    {
        public SuggestionMapping()
        {
            CreateMap<Entities.Suggestion, Models.SuggestionModel>().ReverseMap();
        }
    }
}

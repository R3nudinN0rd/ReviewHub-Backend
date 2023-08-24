using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.SuggestionRepository
{
    public interface ISuggestionRepository
    {
        public Task<SuggestionModel> GetSuggestionByIdAsync(int suggestionId);
        public Task<IEnumerable<SuggestionModel>> GetAllSuggestionsAsync();
        public SuggestionModel AddSuggestion(SuggestionModel suggestion);
        public void UpdateSuggestion(SuggestionModel suggestion);
        public void DeleteSuggestion(int suggestionId);
        public bool SuggestionExists(int suggestionId);
    }
}

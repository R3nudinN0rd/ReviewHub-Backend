using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReviewHub.Contexts;
using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.SuggestionRepository
{
    public class SuggestionRepository : ISuggestionRepository
    {
        private readonly ReviewHubContext _reviewHubContext;
        private readonly IMapper _mapper;
        public SuggestionRepository(ReviewHubContext reviewHubContext, IMapper mapper)
        {
            _reviewHubContext = reviewHubContext ?? throw new ArgumentNullException(nameof(reviewHubContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public SuggestionModel AddSuggestion(SuggestionModel suggestion)
        {
            try
            {
                _reviewHubContext.Suggestions.Add(
                    _mapper.Map<Suggestion>(suggestion)
                    );
                return suggestion;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _reviewHubContext.SaveChanges();
            }
        }

        public void DeleteSuggestion(int suggestionId)
        {
            var suggestionToDelete = _reviewHubContext.Suggestions.FirstOrDefault(suggestion => suggestion.Id == suggestionId);
            try
            {
                _reviewHubContext.Suggestions.Remove(suggestionToDelete);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally 
            {
                _reviewHubContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<SuggestionModel>> GetAllSuggestionsAsync()
        {
            return _mapper.Map<IQueryable<SuggestionModel>>(
                await _reviewHubContext.Suggestions.ToListAsync()
                );
        }

        public async Task<SuggestionModel> GetSuggestionByIdAsync(int suggestionId)
        {
            return _mapper.Map<SuggestionModel>(
                await _reviewHubContext.Suggestions.FirstOrDefaultAsync(suggestion => suggestion.Id == suggestionId)
                );
        }

        public bool SuggestionExists(int suggestionId)
        {
            var suggestion = _reviewHubContext.Suggestions.FirstOrDefault(s => s.Id == suggestionId);
            return suggestion != null;
        }

        public void UpdateSuggestion(SuggestionModel suggestion)
        {
            try
            {
                var existingSuggestion = _reviewHubContext.Suggestions.FirstOrDefault(s => s.Id == suggestion.Id);
                _reviewHubContext.Suggestions.Update(
                    _mapper.Map(suggestion, existingSuggestion)
                    );
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                _reviewHubContext.SaveChanges();
            }
        }
    }
}

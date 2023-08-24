using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ReviewHub.Models;
using ReviewHub.Repositories.SuggestionRepository;

namespace ReviewHub.Controllers
{
    [ApiController]
    [Route("review-hub-api/[controller]")]
    public class SuggestionController : ControllerBase
    {
        private readonly ISuggestionRepository _suggestionRepository;
        public SuggestionController(ISuggestionRepository suggestionRepository)
        {
            _suggestionRepository = suggestionRepository ?? throw new ArgumentNullException(nameof(suggestionRepository));
        }

        [HttpGet]
        [ResponseCache(Duration = 1800, Location = ResponseCacheLocation.Any)]
        public ActionResult<IEnumerable<SuggestionModel>> GetAllSuggestions()
        {
            return Ok(_suggestionRepository.GetAllSuggestionsAsync().Result);
        }

        [HttpGet("{suggestionId}", Name = "GetSuggestionById")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"suggestionId"})]
        public ActionResult<SuggestionModel> GetSuggestionById(int suggestionId)
        {
            return _suggestionRepository.SuggestionExists(suggestionId)==false ?
                            NotFound("Suggestion not found!") : 
                            Ok(_suggestionRepository.GetSuggestionByIdAsync(suggestionId).Result);
        }

        [HttpPost]
        public ActionResult AddSuggestion(SuggestionModel suggestion)
        {
            _suggestionRepository.AddSuggestion(suggestion);
            return CreatedAtRoute("GetSuggestionById",
                                  new { suggestionId = suggestion.Id },
                                  suggestion);
        }

        [HttpPut]
        public ActionResult UpdateSuggestion(SuggestionModel suggestion)
        {
            if(_suggestionRepository.SuggestionExists(suggestion.Id) == false)
            {
                return NotFound("Suggestion not found!");
            }

            _suggestionRepository.UpdateSuggestion(suggestion);
            return Ok("Suggestion updated!");
        }

        [HttpDelete]
        public ActionResult DeleteSuggestion(int suggestionId)
        {
            if(_suggestionRepository.SuggestionExists(suggestionId) == false)
            {
                return NotFound("Suggestion not found!");
            }

            _suggestionRepository.DeleteSuggestion(suggestionId);
            return Ok("Suggestion deleted!");
        }
    }
}

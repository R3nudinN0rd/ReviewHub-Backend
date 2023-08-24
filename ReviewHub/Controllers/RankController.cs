using Microsoft.AspNetCore.Mvc;
using ReviewHub.Models;
using ReviewHub.Repositories.RankRepository;

namespace ReviewHub.Controllers
{
    [ApiController]
    [Route("review-hub-api/[controller]")]
    public class RankController : ControllerBase
    {
        private readonly IRankRepository _rankRepository;
        public RankController(IRankRepository rankRepository)
        {
            _rankRepository = rankRepository ?? throw new ArgumentNullException(nameof(rankRepository));
        }

        [HttpGet]
        [ResponseCache(Duration = 1800, Location = ResponseCacheLocation.Any)]
        public ActionResult<IEnumerable<RankModel>> GetAllRanks()
        {
            return Ok(_rankRepository.GetAllRanksAsync().Result);
        }

        [HttpGet("{rankId}", Name = "GetRankById")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"rankId"})]
        public ActionResult<RankModel> GetRankById(int rankId) 
        {
            return _rankRepository.RankExists(rankId) == false ?
                                NotFound("Rank not found!") :
                                Ok(_rankRepository.GetRankByIdAsync(rankId));
        }

        [HttpPost]
        public ActionResult AddRank(RankModel rank)
        {
            _rankRepository.AddRank(rank);
            return CreatedAtRoute("GetRankById",
                                  new { rankId = rank.Id },
                                  rank);
        }

        [HttpPut]
        public ActionResult Update(RankModel rank)
        {
            if(_rankRepository.RankExists(rank.Id) == false)
            {
                return NotFound("Rankl not found!");
            }

            _rankRepository.UpdateRank(rank);
            return Ok("Rank updated!");
        }

        [HttpDelete]
        public ActionResult DeleteRank(int rankId)
        {
            if(_rankRepository.RankExists(rankId) == false)
            {
                return NotFound("Rank not found!");
            }

            _rankRepository.DeleteRank(rankId);
            return Ok("Rank deleted!");
        }
    }
}

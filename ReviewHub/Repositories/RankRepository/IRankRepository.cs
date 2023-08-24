using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.RankRepository
{
    public interface IRankRepository
    {
        public Task<RankModel> GetRankByIdAsync(int rankId);
        public Task<IEnumerable<RankModel>> GetAllRanksAsync();
        public RankModel AddRank(RankModel rank);
        public void UpdateRank(RankModel rank);
        public void DeleteRank(int rankId);
        public bool RankExists(int rankId);
    }
}

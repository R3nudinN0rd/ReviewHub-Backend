using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReviewHub.Contexts;
using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.RankRepository
{
    public class RankRepository : IRankRepository
    {
        private readonly ReviewHubContext _reviewHubContext;
        private readonly IMapper _mapper;
        public RankRepository(ReviewHubContext reviewHubContext, IMapper mapper)
        {
            _reviewHubContext = reviewHubContext ?? throw new ArgumentNullException(nameof(reviewHubContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public RankModel AddRank(RankModel rank)
        {
            try
            {
                _reviewHubContext.Ranks.Add(
                        _mapper.Map<Rank>(rank)
                    );
                return rank;
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

        public void DeleteRank(int rankId)
        {
            var rankToDelete = _reviewHubContext.Ranks.FirstOrDefault(rank => rank.Id == rankId);
            try
            {
                _reviewHubContext.Ranks.Remove(rankToDelete);
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

        public async Task<IEnumerable<RankModel>> GetAllRanksAsync()
        {
            return _mapper.Map<IEnumerable<RankModel>>(
                    await _reviewHubContext.Ranks.ToListAsync()
                );
        }

        public async Task<RankModel> GetRankByIdAsync(int rankId)
        {
            return _mapper.Map<RankModel>(
                    await _reviewHubContext.Ranks.FirstOrDefaultAsync(rank => rank.Id == rankId)
                   );
        }

        public bool RankExists(int rankId)
        {
            var rank = _reviewHubContext.Ranks.FirstOrDefault( rank => rank.Id == rankId);
            return rank != null;
        }

        public void UpdateRank(RankModel rank)
        {
            try
            {
                var existingRank = _reviewHubContext.Ranks.FirstOrDefault(r => r.Id == rank.Id);
                    _reviewHubContext.Ranks.Update(
                         _mapper.Map(rank, existingRank)
                        );
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
    }
}

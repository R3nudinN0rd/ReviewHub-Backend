using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReviewHub.Contexts;
using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.EntityReviewedRepository
{
    public class EntityReviewedRepository : IEntityReviewedRepository
    {
        private readonly ReviewHubContext _reviewHubContext;
        private readonly IMapper _mapper;
        public EntityReviewedRepository(ReviewHubContext reviewHubContext, IMapper mapper)
        {
            _reviewHubContext = reviewHubContext ?? throw new ArgumentNullException(nameof(reviewHubContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public EntityReviewedModel AddEntityReviewed(EntityReviewedModel entityReviewed)
        {
            try
            {
                _reviewHubContext.EntitiesReviewed.Add(
                        _mapper.Map<EntityReviewed>(entityReviewed)
                    );
                return entityReviewed;
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

        public void DeleteEntityReviewed(int entityReviewedId)
        {
            var entityReviewedToDelete = _reviewHubContext.EntitiesReviewed.FirstOrDefault(entityReviewed => entityReviewed.Id == entityReviewedId);
            try
            {
                _reviewHubContext.EntitiesReviewed.Remove(entityReviewedToDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _reviewHubContext.SaveChanges();
            }
        }

        public bool EntityReviewedExists(int entityReviewedId)
        {
            var entityreviewed = _reviewHubContext.EntitiesReviewed.FirstOrDefault(entityReviewed => entityReviewed.Id == entityReviewedId);
            return entityreviewed != null;
        }

        public async Task<IEnumerable<EntityReviewedModel>> GetAllEntitesReviewedAsync()
        {
            return _mapper.Map<IEnumerable<EntityReviewedModel>>(
                        await _reviewHubContext.EntitiesReviewed.ToListAsync()
                    );
        }

        public async Task<EntityReviewedModel> GetEntityReviewedByIdAsync(int entityReviewedId)
        {
            return _mapper.Map<EntityReviewedModel>(
                        await _reviewHubContext.EntitiesReviewed.FirstOrDefaultAsync(entityReviewed => entityReviewed.Id == entityReviewedId)
                    );
        }

        public void UpdateEntityReviewed(EntityReviewedModel entityReviewed)
        {
            try
            {
                var existingEntityReviewed = _reviewHubContext.EntitiesReviewed.FirstOrDefault(er => er.Id == entityReviewed.Id);
                   _reviewHubContext.EntitiesReviewed.Update(
                          _mapper.Map(entityReviewed, existingEntityReviewed)
                        );
            }
            catch (Exception ex)
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

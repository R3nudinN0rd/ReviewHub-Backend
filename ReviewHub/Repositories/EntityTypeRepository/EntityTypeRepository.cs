using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReviewHub.Contexts;
using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.EntityTypeRepository
{
    public class EntityTypeRepository : IEntityTypeRepository
    {
        private readonly ReviewHubContext _reviewHubContext;
        private readonly IMapper _mapper; 
        public EntityTypeRepository(ReviewHubContext reviewHubContext, IMapper mapper)
        {
            _reviewHubContext = reviewHubContext ?? throw new ArgumentNullException(nameof(reviewHubContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public EntityTypeModel AddEntityType(EntityTypeModel entityType)
        {
            try
            {
                _reviewHubContext.EntityTypes.Add(
                    _mapper.Map<EntityType>(entityType)
                    );
                return entityType;
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

        public void DeleteEntityType(int entityTypeId)
        {
            var entityTypeToDelete = _reviewHubContext.EntityTypes.FirstOrDefault(entityType => entityType.Id == entityTypeId);
            try
            {
                _reviewHubContext.EntityTypes.Remove(entityTypeToDelete);
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

        public bool EntityTypeExists(int entityTypeId)
        {
            var entityType = _reviewHubContext.EntityTypes.FirstOrDefault(entityType => entityType.Id == entityTypeId);
            return entityType != null;
        }

        public async Task<IEnumerable<EntityTypeModel>> GetAllEntityTypesAsync()
        {
            return _mapper.Map<IEnumerable<EntityTypeModel>>(
                        await _reviewHubContext.EntityTypes.ToListAsync()
                   );
        }

        public async Task<EntityTypeModel> GetEntityTypeByIdAsync(int entityTypeId)
        {
            return _mapper.Map<EntityTypeModel>(
                        await _reviewHubContext.EntityTypes.FirstOrDefaultAsync(entityType => entityType.Id == entityTypeId)
                   );
        }


        public async Task<IQueryable<EntityReviewedModel>> GetAllEntitesReviewedOfASpecificTypeAsync(int entityTypeId)
        {
            return _mapper.Map<IQueryable<EntityReviewedModel>>(
                    await _reviewHubContext.EntitiesReviewed.Where(entityType => entityType.Id == entityTypeId).ToListAsync()
                );
        }

        public void UpdateEntityType(EntityTypeModel entityType)
        {
            try
            {
                var existingEntityType = _reviewHubContext.EntityTypes.FirstOrDefault(et => et.Id == entityType.Id);
                _reviewHubContext.EntityTypes.Update(
                    _mapper.Map(entityType, existingEntityType)
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

using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.EntityTypeRepository
{
    public interface IEntityTypeRepository
    {
        public Task<EntityTypeModel> GetEntityTypeByIdAsync(int entityTypeId);
        public Task<IEnumerable<EntityTypeModel>> GetAllEntityTypesAsync();
        public EntityTypeModel AddEntityType(EntityTypeModel entityType);
        public Task<IQueryable<EntityReviewedModel>> GetAllEntitesReviewedOfASpecificTypeAsync(int entityTypeId);
        public void UpdateEntityType(EntityTypeModel entityType);
        public void DeleteEntityType(int entityTypeId);
        public bool EntityTypeExists(int entityTypeId);
    }
}

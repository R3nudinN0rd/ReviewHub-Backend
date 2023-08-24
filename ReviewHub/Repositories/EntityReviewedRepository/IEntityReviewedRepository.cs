using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.EntityReviewedRepository
{
    public interface IEntityReviewedRepository
    {
        public Task<EntityReviewedModel> GetEntityReviewedByIdAsync(int entityReviewedId);
        public Task<IEnumerable<EntityReviewedModel>> GetAllEntitesReviewedAsync();
        public EntityReviewedModel AddEntityReviewed(EntityReviewedModel entityReviewed);
        public void UpdateEntityReviewed(EntityReviewedModel entityReviewed);
        public void DeleteEntityReviewed(int entityReviewedId);
        public bool EntityReviewedExists(int entityReviewedId);
    }
}

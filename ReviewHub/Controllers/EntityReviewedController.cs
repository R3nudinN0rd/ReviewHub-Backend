using Microsoft.AspNetCore.Mvc;
using ReviewHub.Models;
using ReviewHub.Repositories.EntityReviewedRepository;

namespace ReviewHub.Controllers
{
    [ApiController]
    [Route("review-hub-api/[controller]")]
    public class EntityReviewedController : ControllerBase
    {
        private readonly IEntityReviewedRepository _entityReviewedRepository;
        public EntityReviewedController(IEntityReviewedRepository entityReviewedRepository)
        {
            _entityReviewedRepository = entityReviewedRepository ?? throw new ArgumentNullException(nameof(entityReviewedRepository));
        }

        [HttpGet]
        [ResponseCache(Duration = 1800, Location = ResponseCacheLocation.Any)]
        public ActionResult<IEnumerable<EntityReviewedModel>> GetAllEntityReviewed()
        {
            return Ok(_entityReviewedRepository.GetAllEntitesReviewedAsync().Result);
        }

        [HttpGet("{entityReviewedId}", Name = "GetEntityReviewedById")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"entityReviewedId"})]
        public ActionResult<EntityReviewedModel> GetEntityReviewedById(int entityReviewedId)
        {
            return _entityReviewedRepository.EntityReviewedExists(entityReviewedId) == false ?
                                NotFound("Entity reviewed not found!") :
                                Ok(_entityReviewedRepository.GetEntityReviewedByIdAsync(entityReviewedId).Result);
        }

        [HttpPost]
        public ActionResult AddEntityReviewed(EntityReviewedModel entityReviewed)
        {
            _entityReviewedRepository.AddEntityReviewed(entityReviewed);
            return CreatedAtRoute("GetEntityReviewed",
                                  new {entityReviewedId =  entityReviewed.Id},
                                  entityReviewed);
        }

        [HttpPut]
        public ActionResult UpdateEntityReviewed(EntityReviewedModel entityReviewed)
        {
            if(_entityReviewedRepository.EntityReviewedExists(entityReviewed.Id) == false)
            {
                return NotFound("EntityReviewed not found!");
            }

            _entityReviewedRepository.UpdateEntityReviewed(entityReviewed);
            return Ok("Entity reviewed updated!");
        }

        [HttpDelete]
        public ActionResult DeleteEntityReviewed(int entityReviewedId)
        {
            if (_entityReviewedRepository.EntityReviewedExists(entityReviewedId) == false)
            {
                return NotFound("Entity reviwed not found!");
            }

            _entityReviewedRepository.DeleteEntityReviewed(entityReviewedId);
            return Ok("Entity reviewed deleted!");
        }
    }
}

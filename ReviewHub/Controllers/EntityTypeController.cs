using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using ReviewHub.Models;
using ReviewHub.Repositories.EntityTypeRepository;

namespace ReviewHub.Controllers
{
    [ApiController]
    [Route("review-hub-api/[controller]")]
    public class EntityTypeController : ControllerBase
    {
        private readonly IEntityTypeRepository _entityTypeRepository;
        public EntityTypeController(IEntityTypeRepository entityTypeRepository)
        {
            _entityTypeRepository = entityTypeRepository ?? throw new ArgumentNullException(nameof(entityTypeRepository));
        }

        [HttpGet]
        [ResponseCache(Duration = 1800, Location = ResponseCacheLocation.Any)]
        public ActionResult<IEnumerable<EntityTypeModel>> GetAllEntityTypes()
        {
            return Ok(_entityTypeRepository.GetAllEntityTypesAsync().Result);
        }

        [HttpGet("{entityTypeId}", Name = "GetEntityTypeById")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"entityTypeId"})]
        public ActionResult<EntityTypeModel> GetEntityTypeById(int entitytypeId)
        {
            return _entityTypeRepository.EntityTypeExists(entitytypeId) == false ?
                                NotFound("Entity type not found!") :
                                Ok(_entityTypeRepository.GetEntityTypeByIdAsync(entitytypeId).Result);
        }

        [HttpGet("entity-reviewed/{entityTypeId}")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"entityTypeId"})]
        public ActionResult<EntityReviewedModel> GetEntityReviewedByEntityType(int entityTypeId)
        {
            return _entityTypeRepository.EntityTypeExists(entityTypeId) == false ?
                                 NotFound("Entity type not found!") :
                                 Ok(_entityTypeRepository.GetAllEntitesReviewedOfASpecificTypeAsync(entityTypeId).Result);
        }

        [HttpPost]
        public ActionResult AddEntityType(EntityTypeModel entityType)
        {
            _entityTypeRepository.AddEntityType(entityType);
            return CreatedAtRoute("GetEntityTypeById",
                                  new { entityTypeId = entityType.Id },
                                  entityType);
        }

        [HttpPut]
        public ActionResult UpdateEntityType(EntityTypeModel entityType)
        {
            if(_entityTypeRepository.EntityTypeExists(entityType.Id) == false)
            {
                return NotFound("Entity type not found!");
            }

            _entityTypeRepository.UpdateEntityType(entityType);
            return Ok("Entity type updated!");
        }

        [HttpDelete]
        public ActionResult DeleteEntityType(int entitytypeId)
        {
            if(_entityTypeRepository.EntityTypeExists(entitytypeId) == false)
            {
                return NotFound("Entity type not found!");
            }

            _entityTypeRepository.DeleteEntityType(entitytypeId);
            return Ok("Entity type deleted!");
        }

    }
}

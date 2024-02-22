using Microsoft.AspNetCore.Mvc;
using ActorRepositoryLib; 

namespace RestExercise1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ActorsRepository _actorsRepository;

        // Constructor injection of the ActorsRepository
        public ActorsController(ActorsRepository actorsRepository)
        {
            _actorsRepository = actorsRepository;
        }

        // GET: api/Actors
        [HttpGet]
        public ActionResult<IEnumerable<Actor>> Get()
        {
            return Ok(_actorsRepository.Get());
        }

        // GET api/Actors/5
        [HttpGet("{id}")]
        public ActionResult<Actor> Get(int id)
        {
            var actor = _actorsRepository.Get().FirstOrDefault(a => a.Id == id);

            if (actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }

        // POST api/Actors
        [HttpPost]
        public ActionResult<Actor> Post([FromBody] Actor actor)
        {
            var addedActor = _actorsRepository.Add(actor);
            return CreatedAtAction(nameof(Get), new { id = addedActor.Id }, addedActor);
        }

        // PUT api/Actors/5
        [HttpPut("{id}")]
        public ActionResult<Actor> Put(int id, [FromBody] Actor actor)
        {
            if (id != actor.Id)
            {
                return BadRequest();
            }

            var updatedActor = _actorsRepository.Update(id, actor);

            if (updatedActor == null)
            {
                return NotFound();
            }

            return Ok(updatedActor);
        }

        // DELETE api/Actors/5
        [HttpDelete("{id}")]
        public ActionResult<Actor> Delete(int id)
        {
            var actor = _actorsRepository.Delete(id);

            if (actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }
    }
}

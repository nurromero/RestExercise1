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
        public IEnumerable<Actor> Get()
        {
            return _actorsRepository.Get();
   
        }

        // GET api/Actors/5
        [HttpGet("{id}")]
        public Actor Get(int id)
        {
            return _actorsRepository.GetId(id);

        }

        // POST api/Actors
        [HttpPost]
        public Actor Post([FromBody] Actor actor)
        {
            return _actorsRepository.Add(actor);
        }

        // PUT api/Actors/5
        [HttpPut("{id}")]
        public Actor Put(int id, [FromBody] Actor actor)
        {
            return _actorsRepository?.Update(id, actor)!;
        }

        // DELETE api/Actors/5
        [HttpDelete("{id}")]
        public Actor Delete(int id)
        {
            return _actorsRepository?.Delete(id)!;
        }
    }
}

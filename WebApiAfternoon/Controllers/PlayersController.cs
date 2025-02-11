using Microsoft.AspNetCore.Mvc;
using WebApiAfternoon.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAfternoon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private static List<Player> players = new List<Player>
        {
            new Player
            {
                Id=1,
                PlayerName="John Doe",
                City="Los Angelos",
                Score=90
            },
            new Player
            {
                Id=2,
                PlayerName="Lebron James",
                City="New York",
                Score=99
            },
        };
        // GET: api/<PlayersController> api/players 
        [HttpGet]
        public ActionResult<IEnumerable<Player>> GetPlayers()
        {
            return Ok(players);
        }

        // GET api/<PlayersController>/5
        [HttpGet("{id}")]
        public ActionResult<Player> Get(int id)
        {
            var player = players.FirstOrDefault(x => x.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        // POST api/<PlayersController>
        [HttpPost]
        public ActionResult<Player> Post([FromBody] Player newPlayer)
        {
            newPlayer.Id = players.Any() ? players.Max(x => x.Id) + 1 : 1;
            players.Add(newPlayer);
            //return Ok(newPlayer);// 200 and object
            //return Created();// 201
            return CreatedAtAction(nameof(Get), new { id = newPlayer.Id }, newPlayer);// 201
        }

        // PUT api/<PlayersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlayersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PokeAPI.Models;

namespace PokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private DataContext _context;

        public PokemonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pokemon>>> GetAllPokemon()
        {
            return Ok(await _context.Pokemon.Include(ptype => ptype.Type1).Include(ptype => ptype.Type2).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetSinglePokemon(int id)
        {
            var dbPokemon = await _context.Pokemon.Include(ptype => ptype.Type1).Include(ptype => ptype.Type2).FirstAsync(p => p.PokemonID == id);
            if (dbPokemon == null)
                return NotFound("Pokemon not found.");
            return Ok(dbPokemon);
        }

        [HttpPost]
        public async Task<ActionResult<List<Pokemon>>> AddPokemon(Pokemon pokemon)
        {
            _context.Pokemon.Add(pokemon);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Pokemon.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Pokemon>>> UpdatePokemon(Pokemon request)
        {
            var dbPokemon = await _context.Pokemon.FindAsync(request.PokemonID);
            if (dbPokemon == null)
                return NotFound("Pokemon not found.");

            dbPokemon.PokemonID = request.PokemonID;
            dbPokemon.PokemonName = request.PokemonName;
            dbPokemon.Type1 = request.Type1;
            dbPokemon.Type2 = request.Type2;

            await _context.SaveChangesAsync();

            return Ok(await _context.Pokemon.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Pokemon>>> DeletePokemon(int id)
        {
            var dbPokemon = await _context.Pokemon.FindAsync(id);
            if (dbPokemon == null)
                return BadRequest("Pokemon not found.");

            _context.Pokemon.Remove(dbPokemon);
            await _context.SaveChangesAsync();

            return Ok(await _context.Pokemon.ToListAsync());
        }
    }
}

using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeAPI.Models;

namespace PokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private PokemonContext _context;

        public PokemonController(PokemonContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pokemon>>> GetAllPokemon()
        {
            return Ok(await _context.Pokemon.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetSinglePokemon(int id)
        {
            var dbPokemon = await _context.Pokemon.FindAsync(id);
            if (dbPokemon == null)
                return BadRequest("Pokemon not found.");
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
                return BadRequest("Pokemon not found.");

            dbPokemon.PokemonID = request.PokemonID;
            dbPokemon.PokemonName = request.PokemonName;

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

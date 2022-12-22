namespace PokeAPI.Models
{
    public class Pokemon
    {
        public int PokemonID { get; set; } = 0;
        public string PokemonName { get; set; } = string.Empty;
        public Types? Type1 { get; set; }
        public Types? Type2 { get; set; }
    }
}

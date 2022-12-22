namespace PokeAPI.Models
{
    public class Pokemon
    {
        public int PokemonID { get; set; } = 0;
        public string PokemonName { get; set; } = string.Empty;
        public Type? Type1 { get; set; }
        public Type? Type2 { get; set; }
    }
}

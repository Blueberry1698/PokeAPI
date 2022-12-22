using System.ComponentModel.DataAnnotations;

namespace PokeAPI.Models
{
    public class Types
    {
        [Key]
        public int TypeID { get; set; } = 0;
        public string TypeName { get; set; } = string.Empty;
    }
}

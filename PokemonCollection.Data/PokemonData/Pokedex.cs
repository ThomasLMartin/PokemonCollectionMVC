using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCollection.Data
{
    public class Pokedex
    {
        [Key]
        public int PokedexID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        public virtual ICollection<PokedexEntry> PokedexEntries { get; set; } = new List<PokedexEntry>();

    }
}

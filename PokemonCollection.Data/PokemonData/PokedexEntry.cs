using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCollection.Data
{
    public class PokedexEntry
    {
        [Key]
        public int PokedexEntryID { get; set; }

        [ForeignKey(nameof(Pokemon))]
        public int PokemonID { get; set; }
        public virtual Pokemon Pokemon { get; set; }

        [ForeignKey(nameof(Pokedex))]
        public int PokedexID { get; set; }
        public virtual Pokedex Pokedex { get; set; }

        [Required]
        public DateTime DateCaught { get; set; }
    }
}

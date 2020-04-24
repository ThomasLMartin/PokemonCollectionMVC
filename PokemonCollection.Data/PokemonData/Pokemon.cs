using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCollection.Data
{
    public class Pokemon
    {
        [Key]
        public int PokemonID { get; set; }

        [Required]
        public string PokemonName { get; set; }

        [ForeignKey(nameof(Region))]
        public int RegionID { get; set; }
        public virtual Region Region { get; set; }
        
        [ForeignKey(nameof(Type))]
        public int TypeID { get; set; }
        public virtual Type Type { get; set; }
        
        public bool IsShiny { get; set; }

        public virtual ICollection<PokedexEntry> NewPokedexEntries { get; set; } = new List<PokedexEntry>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCollection.Data
{
    public class PokedexEntry
    {
        [Key]
        public int PokedexEntryID { get; set; }


        public int PokemonID { get; set; }


        public int PokedexID { get; set; }

        [Required]
        public DateTime DateCaught { get; set; }
    }
}

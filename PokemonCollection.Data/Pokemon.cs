using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        public int RegionID { get; set; }
        
        
        public int TypeID { get; set; }
        
        public bool IsShiny { get; set; }

    }
}

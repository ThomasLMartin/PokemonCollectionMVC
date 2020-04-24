using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCollection.Models.PokemonModels
{
    public class PokemonListItem
    {
        public int PokemonID { get; set; }

        public string PokemonName { get; set; }

        public int RegionID { get; set; }

        public int TypeID { get; set; }

        public bool IsShiny { get; set; }
    }
}

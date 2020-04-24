using PokemonCollection.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCollection.Models.PokemonModels
{
    public class PokemonCreate
    {
        [Required]
        public string PokemonName { get; set; }

        [Required]
        public int RegionID { get; set; }

        [Required]
        public int TypeID { get; set; }

        public bool IsShiny { get; set; }
    }
}

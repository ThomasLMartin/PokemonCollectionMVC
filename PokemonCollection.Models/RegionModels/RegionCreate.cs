using PokemonCollection.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCollection.Models.RegionModels
{
    public class RegionCreate
    {
        [Required]
        public string RegionName { get; set; }

        [Required]
        public string LocationInRegion { get; set; }
    }
}

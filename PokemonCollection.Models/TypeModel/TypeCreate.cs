using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCollection.Models.TypeModel
{
    public class TypeCreate
    {
        [Required]
        public string TypeName { get; set; }
    }
}

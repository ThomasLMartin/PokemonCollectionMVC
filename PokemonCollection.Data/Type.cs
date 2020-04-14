using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCollection.Data
{
    public class Type
    {
        [Key]
        public int TypeID { get; set; }

        [Required]
        public string TypeName { get; set; }
    }
}

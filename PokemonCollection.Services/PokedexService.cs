using PokemonCollection.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCollection.Services
{
    public class PokedexService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //Create
        public bool CreatePokedex(PokedexCreate model)
        {

        }

    }
}

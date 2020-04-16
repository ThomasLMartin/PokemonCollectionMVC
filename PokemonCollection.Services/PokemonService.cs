using PokemonCollection.Data;
using PokemonCollection.Models.PokemonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCollection.Services
{
    public class PokemonService
    {
        private readonly Guid _userID;

        public PokemonService(Guid userId)
        {
            _userID = userId;
        }

        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //Create
        public bool CreatePokemon(PokemonCreate model)
        {
            Pokemon entity = new Pokemon
            {
                PokemonName = model.PokemonName,
                RegionID = model.RegionID,
                TypeID = model.TypeID,
                IsShiny = model.IsShiny
            };

            _context.Pokemon.Add(entity);
            return _context.SaveChanges() == 1;
        }

        //Get ALL
        public List<PokemonListItem> GetAllPokemon()
        {
            var pokemonEntities = _context.Pokemon.ToList();
            var pokemonList = pokemonEntities.Select(p => new PokemonListItem
            {
                PokemonID = p.PokemonID,
                PokemonName = p.PokemonName,
                RegionID = p.RegionID,
                TypeID = p.TypeID,
                IsShiny = p.IsShiny
            }).ToList();
            return pokemonList;
        }

        //Get (Details by ID)
        public PokemonListItem GetPokemonById(int pokemonId)
        {
            var pokemonEntitiy = _context.Pokemon.Find(pokemonId);
            var pokemonDetail = new PokemonListItem
            {
                PokemonID = pokemonEntitiy.PokemonID,
                PokemonName = pokemonEntitiy.PokemonName,
                RegionID = pokemonEntitiy.RegionID,
                TypeID = pokemonEntitiy.TypeID,
                IsShiny = pokemonEntitiy.IsShiny
            };
            return pokemonDetail;
        }
    }
}

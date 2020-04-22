using PokemonCollection.Data;
using PokemonCollection.Models.PokemonModels;
using PokemonCollection.Models.RegionModels;
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

        public bool CreateRegion(RegionCreate model)
        {
            throw new NotImplementedException();
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
            var pokemonEntity = _context.Pokemon.Find(pokemonId);
            var pokemonDetail = new PokemonListItem
            {
                PokemonID = pokemonEntity.PokemonID,
                PokemonName = pokemonEntity.PokemonName,
                RegionID = pokemonEntity.RegionID,
                TypeID = pokemonEntity.TypeID,
                IsShiny = pokemonEntity.IsShiny
            };
            return pokemonDetail;
        }
    }
}

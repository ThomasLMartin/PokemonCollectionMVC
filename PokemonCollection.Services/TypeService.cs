using PokemonCollection.Data;
using PokemonCollection.Models.TypeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = PokemonCollection.Data.Type;

namespace PokemonCollection.Services
{
    public class TypeService
    {
        private readonly Guid _userID;

        public TypeService(Guid userId)
        {
            _userID = userId;
        }

        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public bool CreateType(TypeCreate model)
        {
            Type entity = new Type
            {
                TypeName = model.TypeName
            };

            _context.Type.Add(entity);
            return _context.SaveChanges() == 1;
        }

        //Get ALL
        public List<TypeListItem> GetAllTypes()
        {
            var typeEntities = _context.Type.ToList();
            var typeList = typeEntities.Select(t => new TypeListItem
            {
                TypeID = t.TypeID,
                TypeName = t.TypeName
            }).ToList();

            return typeList;
        }

        //Get (Details by ID)
        public TypeListItem GetTypeById(int typeId)
        {
            var typeEntity = _context.Type.Find(typeId);
            var typeDetail = new TypeListItem
            {
                TypeID = typeEntity.TypeID,
                TypeName = typeEntity.TypeName
            };
            return typeDetail;
        }
    }
}

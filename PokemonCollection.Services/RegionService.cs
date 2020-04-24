using PokemonCollection.Data;
using PokemonCollection.Models.RegionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCollection.Services
{
    public class RegionService
    {
        private readonly Guid _userID;

        public RegionService(Guid userId)
        {
            _userID = userId;
        }

        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public bool CreateRegion(RegionCreate model)
        {
            Region entity = new Region
            {
                LocationInRegion = model.LocationInRegion,
                RegionName = model.RegionName
            };

            _context.Region.Add(entity);
            return _context.SaveChanges() == 1;
        }

        public List<RegionListItem> GetAllRegions()
        {
            var regionEntities = _context.Region.ToList();
            var regionList = regionEntities.Select(r => new RegionListItem
            {
                RegionID = r.RegionID,
                LocationInRegion = r.LocationInRegion,
                RegionName = r.RegionName

            }).ToList();
            return regionList;
        }

        public RegionListItem GetRegionById(int regionId)
        {
            var regionEntity = _context.Region.Find(regionId);
            var regionDetail = new RegionListItem
            {
                RegionID = regionEntity.RegionID,
                LocationInRegion = regionEntity.LocationInRegion,
                RegionName = regionEntity.RegionName
            };
            return regionDetail;
        }
    }
}

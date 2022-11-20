using HighFantasyStore.Server.Data;
using HighFantasyStore.Server.Models;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace HighFantasyStore.Server.Services.Armor
{
    public class ArmorServices : IArmorServices
    {
        private readonly ApplicationDbContext _context;

        public ArmorServices(ApplicationDbContext context)
        {
            _context = context;
        }
        private string _UserID;
        public void SetUserId(string userID) => _UserID = userID;
        public async Task<bool> CreateArmorAsync(ArmorCreate model)
        {
            var ArmorEntity = new Armor
            {
                Price = model.Price,
                Rarity = model.Rarity,
                Name = model.Name,
                proprerties = model.proprerties,
                MagicID = model.MagicID,
                quantity = model.quantity
            };
            _context.Armors.Add(ArmorEntity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<IEnumerable<ArmorListItem>> GetAllArmorAsync()
        {
            var ArmorQuery = _context
                .Armors
                .Select(n =>
                    new ArmorListItem
                    {
                        Id = n.Id,
                        Price = n.Price,
                        Name = n.Name,
                        Rarity = n.Rarity,
                        properties = n.properties,
                        MagicID = n.MagicID,
                        quantity = n.quantity
                    });
            return await ArmorQuery.ToList();
        }
        public async Task<ArmorListItem> GetArmorByIdAsync(int armorId)
        {
            var armorEntity = await _context
                .Armors
                .FirstOrDefaultAsync(n => n.Id == armorId);
            if (armorEntity == null)
                return null;
            var detail = new ArmorListItem
            {
                Id = armorEntity.Id,
                Price = armorEntity.Price,
                Rarity = armorEntity.Rarity,
                Name = armorEntity.Name,
                proprerties = armorEntity.proprerties,
                MagicID = armorEntity.MagicID,
                quantity = armorEntity.quantity
            };
            return detail;
        }
        public async Task<bool> UpdateArmorAsync(ArmorEdit model)
        {
            if (model == null) return false;
            var entity = await _context.Armors.FindAsync(model.Id);
            entity.Price = model.Price;
            entity.Rarity = model.Rarity;
            entity.Name = model.Name;
            entity.Proprerties = model.Proprerties;
            entity.MagicID = model.MagicID;
            entity.quantity = model.quantity;

            return await _context.SaveChangesAsync() == 1;
        }
        public async Task<bool> DeleteArmorAsync(int armorId)
        {
            var entity = await _context.Armors.FindAsync(armorId);
            _context.Armors.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}

using HighFantasyStore.Server.Data;
using HighFantasyStore.Server.Models;
using HighFantasyStore.Shared.Models.Weapons;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace HighFantasyStore.Server.Services.Weapons
{
    public class WeaponsServices : IWeaponsServices
    {
        private readonly ApplicationDbContext _context;

        public WeaponsServices(ApplicationDbContext context)
        {
            _context = context;
        }
        private string _UserID;
        public void SetUserId(string userID) => _UserID = userID;
        public async Task<bool> CreateWeaponsAsync(WeaponCreate model)
        {
            var WeaponEntity = new Weapon
            {
                Id =model.Id,
                Price = model.Price,
                Rarity = model.Rarity,
                Name = model.Name,
                properties = model.properties,
                MagicId = model.MagicID,
                quantity = model.quantity
            };
            _context.Weapons.Add(WeaponEntity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<IEnumerable<WeaponsListItem>> GetAllWeaponsAsync()
        {
            var WeaponsQuery = _context
                .Weapons
                .Select(n =>
                    new WeaponsListItem
                    {
                        Id = n.Id,
                        Price = n.Price,
                        Name = n.Name,
                        Rarity = n.Rarity,
                        properties = n.properties,
                        MagicID = n.MagicId,
                        quantity = n.quantity
                    });
            return await WeaponsQuery.ToListAsync();
        }
        public async Task<WeaponsListItem> GetWeaponsByIdAsync(int weaponId)
        {
            var weaponEntity = await _context
                .Weapons
                .FirstOrDefaultAsync(n => n.Id == weaponId);
            if (weaponEntity == null)
                return null;
            var detail = new WeaponsListItem
            {
                Id = weaponEntity.Id,
                Price = weaponEntity.Price,
                Rarity = weaponEntity.Rarity,
                Name = weaponEntity.Name,
                properties = weaponEntity.properties,
                MagicID = weaponEntity.MagicId,
                quantity = weaponEntity.quantity
            };
            return detail;
        }
        public async Task<bool> UpdateWeaponAsync(WeaponsEdit model)
        {
            if (model == null) return false;
            var entity = await _context.Weapons.FindAsync(model.Id);
            entity.Price = model.Price;
            entity.Rarity = model.Rarity;
            entity.Name = model.Name;
            entity.properties = model.properties;
            entity.MagicId = model.MagicID;
            entity.quantity = model.quantity;

            return await _context.SaveChangesAsync() == 1;
        }
        public async Task<bool> DeleteWeaponAsync(int weaponId)
        {
            var entity = await _context.Weapons.FindAsync(weaponId);
            _context.Weapons.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}


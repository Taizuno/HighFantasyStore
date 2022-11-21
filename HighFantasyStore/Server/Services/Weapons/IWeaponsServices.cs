using HighFantasyStore.Shared.Models.Weapons;

namespace HighFantasyStore.Server.Services.Weapons
{
    public interface IWeaponsServices
    {
        Task<bool> CreateWeaponsAsync(WeaponCreate model);
        Task<IEnumerable<WeaponsListItem>> GetAllWeaponsAsync();
        Task<WeaponsListItem> GetWeaponsByIdAsync(int weaponId);
        Task<bool> UpdateWeaponAsync(WeaponsEdit model);
        Task<bool> DeleteWeaponAsync(int weaponId);
    }
}

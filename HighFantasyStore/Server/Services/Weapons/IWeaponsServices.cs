namespace HighFantasyStore.Server.Services.Weapons
{
    public class IWeaponsServices
    {
        Task<bool> CreateWeaponsAsync(WeaponsCreate model);
        Task<IEnumerable<WeaponsListItem>> GetAllWeaponsAsync();
        Task<WeaponsListItem> GetWeaponsByIdAsync(int weaponId);
        Task<bool> UpdateWeaponAsync(WeaponsEdit model);
        Task<bool> DeleteWeaponAsync(int weaponId);
    }
}

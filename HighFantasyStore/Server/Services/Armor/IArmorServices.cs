namespace HighFantasyStore.Server.Services.Armor
{
    public interface IArmorServices
    {
        Task<bool> CreateArmorAsync(ArmorCreate model);
        Task<IEnumerable<ArmorListItem>> GetAllArmorAsync();
        Task<ArmorListItem> GetArmorByIdAsync(int armorId);
        Task<bool> UpdateArmorAsync(ArmorEdit model);
        Task<bool> DeleteArmorAsync(int armorId);


    }
}

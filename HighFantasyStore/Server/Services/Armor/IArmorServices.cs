using HighFantasyStore.Shared.Models.Armors;
namespace HighFantasyStore.Server.Services.Armors
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

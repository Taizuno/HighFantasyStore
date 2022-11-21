using HighFantasyStore.Shared.Models.Magics;
namespace HighFantasyStore.Server.Services.Magics
{
    public interface IMagicServices
    {
        Task<bool> CreateMagicAsync(MagicCreate model);
        Task<IEnumerable<MagicListItem>> GetAllMagicAsync();
        Task<MagicListItem> GetMagicByIdAsync(int magicId);
        Task<bool> UpdateMagicAsync(MagicEdit model);
        Task<bool> DeleteMagicAsync(int magicId);
    }
}

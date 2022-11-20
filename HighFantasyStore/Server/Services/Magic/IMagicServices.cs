namespace HighFantasyStore.Server.Services.Magic
{
    public class IMagicServices
    {
        Task<bool> CreateMagicAsync(MagicCreate model);
        Task<IEnumerable<MagicListItem>> GetAllMagicAsync();
        Task<MagicListItem> GetMagicByIdAsync(int magicId);
        Task<bool> UpdateMagicAsync(MagicEdit model);
        Task<bool> DeleteMagicAsync(int magicId);
    }
}

using HighFantasyStore.Shared.Models.profiles;
using HighFantasyStore.Shared.Models.Profiles;
namespace HighFantasyStore.Server.Services.Profiles
{
    public interface IProfileServices
    {
        Task<bool> CreateProfileAsync(ProfileCreate model);
        Task<bool> DeleteProfileAsync(int profileId);
        Task<ProfileListItem> GetProfileByIdAsync(int profileId);
        Task<IEnumerable<ProfileListItem>> GetProfilesByOwnerAsync(int userId);
        Task<bool> UpdateProfileAsync(ProfileEdit model);
    }
}

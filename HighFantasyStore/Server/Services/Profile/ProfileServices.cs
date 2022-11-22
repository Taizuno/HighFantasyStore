using AutoMapper;
using HighFantasyStore.Server.Data;
using HighFantasyStore.Server.Models;
using HighFantasyStore.Shared.Models.profiles;
using HighFantasyStore.Shared.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Profile = HighFantasyStore.Server.Models.Profile;

namespace HighFantasyStore.Server.Services.Profiles
{
    public class ProfileServices : IProfileServices
    {
        private readonly ApplicationDbContext _context;

        public ProfileServices(ApplicationDbContext context)
        {
            _context = context;
        }
        private string _UserId;
        public void SetUserId(string userId) => _UserId = userId;
        public async Task<bool> CreateProfileAsync(ProfileCreate model)
        {
            var ProfileEntity = new Profile
            {
                id = model.id,
                ownerId = _UserId,
                gold = model.gold,
            };
            _context.Profiles.Add(ProfileEntity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<bool> DeleteProfileAsync(int profileId)
        {
            var entity = await _context.Profiles.FindAsync(profileId);
            _context.Profiles.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<ProfileListItem> GetProfileByIdAsync(int profileId)
        {
            var profileEntity = await _context
                .Profiles
                .FirstOrDefaultAsync(n => n.id == profileId);
            if(profileEntity == null)
            {
                return null;
            }

            var detail = new ProfileListItem
            {
                Id = profileEntity.id,
                gold = profileEntity.gold,
            };
            return detail;
        }

        public async Task<IEnumerable<ProfileListItem>> GetProfilesByOwnerAsync(int userId)
        {
            var ProfileQuery = _context
                .Profiles
                .Where(n => n.ownerId == _UserId)
                .Select(n => new ProfileListItem
                {
                    Id = n.id,
                    gold = n.gold,
                });
            return await ProfileQuery.ToListAsync();
        }

        public async Task<bool> UpdateProfileAsync(ProfileEdit model)
        {
            if (model == null) return false;
            var entity = await _context.Profiles.FindAsync(model.Id);
            entity.gold = model.gold;

            return await _context.SaveChangesAsync() == 1;
        }

    }
}

using HighFantasyStore.Server.Data;
using HighFantasyStore.Server.Models;
using HighFantasyStore.Shared.Models.Magics;
using Microsoft.EntityFrameworkCore;

namespace HighFantasyStore.Server.Services.Magics
{
    public class MagicServices : IMagicServices
    {
        private readonly ApplicationDbContext _context;

        public MagicServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateMagicAsync(MagicCreate model)
        {
            var MagicEntity = new Magic { Id = model.Id, Description = model.Description };
            _context.Magics.Add(MagicEntity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteMagicAsync(int magicId)
        {
            var entity = await _context.Magics.FindAsync(magicId);
            _context.Magics.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<MagicListItem>> GetAllMagicAsync()
        {
            var MagicQuerry = _context
                .Magics
                .Select(n =>
                new MagicListItem
                {
                    Id = n.Id,
                    Description = n.Description,
                });
            return await MagicQuerry.ToListAsync();
        }

        public async Task<MagicListItem> GetMagicByIdAsync(int magicId)
        {
            var MagicEntity = await _context.Magics.FindAsync(magicId);
            if (MagicEntity == null)
                return null;
            var detail = new MagicListItem
            {
                Id = MagicEntity.Id,
                Description = MagicEntity.Description,
            };
            return detail;
        }

        public async Task<bool> UpdateMagicAsync(MagicEdit model)
        {
            if (model == null) return false;
            var entity = await _context.Magics.FindAsync(model.Id);
            entity.Description = model.Description;

            return await _context.SaveChangesAsync() == 1;
        }
    }
}

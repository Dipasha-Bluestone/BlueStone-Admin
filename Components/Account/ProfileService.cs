using System;
using System.Linq;
using System.Threading.Tasks;
using BlueStone_Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace BlueStone_Admin.Components.Account
{
    public class ProfileService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProfileService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Profile> GetUserProfile(string emailId)
        {
            return await _dbContext.Profile.FirstOrDefaultAsync(p => p.EmailId == emailId);
        }
        public async Task UpdateUserProfile(Profile profile)
        {
            _dbContext.Update(profile);
            await _dbContext.SaveChangesAsync();
        }
    }
}

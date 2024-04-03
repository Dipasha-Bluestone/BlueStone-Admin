using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueStone_Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace BlueStone_Admin.Components.Account
{
    public class ManageEmployeeContext
    {
        private readonly ApplicationDbContext _dbContext;

        public ManageEmployeeContext(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Profile>> GetAllUserProfilesAsync()
        {
            return await _dbContext.Profile.ToListAsync();
        }

        public async Task EditTimeInAsync(string userId, DateTime newTimeIn)
        {
            var userProfile = await _dbContext.HomeModel.FirstOrDefaultAsync(u => u.EmailId == userId);
            if (userProfile != null)
            {
                userProfile.TimeIn = newTimeIn;
                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task EditTimeOutAsync(string userId, DateTime newTimeOut)
        {
            var userProfile = await _dbContext.HomeModel.FirstOrDefaultAsync(u => u.EmailId == userId);
            if (userProfile != null)
            {
                userProfile.TimeOut = newTimeOut;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task EditReportAsync(string userId, string newReport)
        {
            var userProfile = await _dbContext.HomeModel.FirstOrDefaultAsync(u => u.EmailId == userId);
            if (userProfile != null)
            {
                userProfile.Report = newReport;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}


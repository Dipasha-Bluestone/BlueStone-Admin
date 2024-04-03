using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BlueStone_Admin.Components.Account.Pages.Manage;
using BlueStone_Admin.Data;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;

namespace BlueStone_Admin.Components.Account
{
    public class HomeService
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SetTimeIn(string emailId)
        {
            DateTime currentDateUtc = DateTime.Now.Date;
            bool hasTimeIn = await _dbContext.HomeModel.AnyAsync(t => t.EmailId == emailId && t.TimeIn.Date == currentDateUtc);
            TimeZoneInfo istTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            if (!hasTimeIn)
            {
                HomeContext timeLog = new HomeContext
                {
                    EmailId = emailId,
                    Date = currentDateUtc,
                    TimeIn = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, istTimeZone)
            };

                _dbContext.HomeModel.Add(timeLog);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task SetTimeOut(string emailId)
        {
            DateTime currentDateUtc = DateTime.UtcNow.Date;
            TimeZoneInfo istTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            bool hasTimeOut = await _dbContext.HomeModel.AnyAsync(t => t.EmailId == emailId && t.TimeOut != null && t.TimeOut.Value.Date == currentDateUtc);

            if (!hasTimeOut)
            {
                HomeContext timeLog = await _dbContext.HomeModel.FirstOrDefaultAsync(t => t.EmailId == emailId && t.TimeOut == null && t.TimeIn.Date == currentDateUtc);

                if (timeLog != null)
                {
                    timeLog.TimeOut = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, istTimeZone);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task<string> GetDailyReport(string emailId)
        {
            var today = DateTime.Today;
            var report = await _dbContext.HomeModel
                .Where(r => r.EmailId == emailId && r.Date == today)
                .Select(r => r.Report)
                .FirstOrDefaultAsync();
            return report;
        }

        public async Task SaveDailyReport(string emailId, string report)
        {
            var today = DateTime.Today;
            var existingReport = await _dbContext.HomeModel
                .FirstOrDefaultAsync(r => r.EmailId == emailId && r.Date == today);

            if (existingReport != null)
            {
                existingReport.Report = report;
            }
            else
            {
                var newReport = new HomeContext
                {
                    EmailId = emailId,
                    Date = today,
                    Report = report
                };
                _dbContext.HomeModel.Add(newReport);
            }

            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<UserReport>> GetUserReportsForMonth(string month, string emailId)
        {
                int monthNumber = DateTime.ParseExact(month, "MMMM", CultureInfo.InvariantCulture).Month;

            var userReports = await _dbContext.HomeModel
                .Where(r => r.EmailId == emailId && r.Date.Month == monthNumber)
                .Select(r => new UserReport
                {

                    Date = r.Date,
                    LoginTime = r.TimeIn,
                    LogoutTime = r.TimeOut,
                    Text = r.Report
                })
                .ToListAsync();

            return userReports;
            
            
        }
        public async Task SaveRecords(List<UserReport> records)
        {
            
            foreach (var record in records)
            {
                var existingRecord = await _dbContext.UserReport.FindAsync(record.Id);
                if (existingRecord != null)
                {
                    existingRecord.Date = record.Date;
                    existingRecord.LoginTime = record.LoginTime;
                    existingRecord.LogoutTime = record.LogoutTime;
                    existingRecord.Text = record.Text;
                }
                else
                {
                    _dbContext.UserReport.Add(record); 
                }
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}


using AgeApp.Models.Data;
using AgeApp.Models.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AgeApp.Models.Access
{
    public class UserAgeAccess
    {
        private ApplicationDbContext adb = new ApplicationDbContext();

        public async Task<int> AddUserAge(UserAgeProfile userProfile)
        {
            try
            {
                adb.UserAges.Add(userProfile);
                return await adb.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AgeViewModel> GetAgeViewModel(string email)
        {
            AgeViewModel avm = new AgeViewModel();

            try
            {
                avm.UserProfile = await adb.UserAges.FirstOrDefaultAsync(x => x.Email == email.ToLower());

                List<UserAgeProfile> userAges = await adb.UserAges.OrderBy(x => x.Age).ToListAsync();
                if(userAges.Count > 0)
                {
                    avm.MinimumAge = userAges.First().Age;
                    avm.MaximumAge = userAges.Last().Age;
                    avm.AgeFrequencies = new int[(avm.MaximumAge - avm.MinimumAge) + 1];
                }
                foreach(UserAgeProfile user in userAges) 
                {
                    avm.AgeFrequencies[user.Age - avm.MinimumAge]++;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return avm;
        }
    }
}
using inventoryManagementCore.Data;
using inventoryManagementCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventoryManagementCore.Services.Utilities
{
    public class Utilities : IUtilities
    {
        private readonly DataContext _context;

        public Utilities(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Utility>> SetToken(Utility utility)
        {
            var serviceResponse = new ServiceResponse<Utility>();

            var utilityWithToken = await _context.Utilities.FirstOrDefaultAsync(util => util.Name == utility.Name);

            if(utilityWithToken == null)
            {
                _context.Utilities.Add(utility);
                await _context.SaveChangesAsync();
                serviceResponse.Data = utility;

            }
            else
            {
                utilityWithToken.Name = utility.Name;
                utilityWithToken.Value = utility.Value;
                serviceResponse.Data = utilityWithToken;
            }

            await _context.SaveChangesAsync();


            return serviceResponse;
        }

        public async Task<string> GetToken(string utilityName)
        {
            var utilityWithToken = await _context.Utilities.FirstOrDefaultAsync(util => util.Name == utilityName);

            return utilityWithToken.Value;
        }
    }
}

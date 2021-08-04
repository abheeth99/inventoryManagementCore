using inventoryManagementCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventoryManagementCore.Services.Utilities
{
    public interface IUtilities
    {
        Task<ServiceResponse<Utility>> SetToken(Utility utility);
        Task<string> GetToken(string utilityName);
    }
}

using SpaceXInfo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceXInfo.Repositories
{
    public interface ISpaceXRepository
    {
        Task<IEnumerable<LaunchPad>> GetLaunchPadInfoAsync();
        Task<LaunchPad> GetLaunchPadInfoByNameAsync(string padname);
    }
}

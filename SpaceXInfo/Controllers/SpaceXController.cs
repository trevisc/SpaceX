using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceXInfo.Repositories;
using SpaceXInfo.Models;
using Microsoft.Extensions.Logging;

namespace SpaceXInfo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SpaceXController : Controller
    {
        private readonly ILogger _logger;
        readonly private ISpaceXRepository _repo;

        public SpaceXController(ISpaceXRepository repo, ILoggerFactory logger)
        {
            _repo = repo;
            _logger = logger.CreateLogger("SpaceXControllerLogger");
        }

        [HttpGet]
        [Route("GetLaunchPadInfo")]
        public async Task<IEnumerable<LaunchPad>> Get()
        {
           var results = await _repo.GetLaunchPadInfoAsync();
            if(results == null)
            {
                _logger.LogError("No results found in GetLaunchPadInfo");
            }
            return results;        
        }
        
        [HttpGet]
        [Route("GetLaunchPadInfo/{padname}")]
        public async Task<LaunchPad> Get(string padname)
        {             
            var results = await _repo.GetLaunchPadInfoByNameAsync(padname);
            if (results == null)
            {
                _logger.LogError("Padname not found or no results available.");                
            }
            return results;
        }
    }
}


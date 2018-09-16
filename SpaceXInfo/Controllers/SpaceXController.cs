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
        private readonly ISpaceXRepository _repo;

        public SpaceXController(ISpaceXRepository repo, ILoggerFactory logger)
        {
            _repo = repo;
            _logger = logger.CreateLogger("SpaceXControllerLogger");
        }

        [HttpGet]
        [Route("GetLaunchPadInfo")]
        public async Task<ActionResult> Get()
        {
            IEnumerable<LaunchPad> results = await _repo.GetLaunchPadInfoAsync().ConfigureAwait(true);
            if(results == null)
            {
                _logger.LogError("No results found in GetLaunchPadInfo");
            }
           return View("~/Views/LaunchPads.cshtml", results);
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


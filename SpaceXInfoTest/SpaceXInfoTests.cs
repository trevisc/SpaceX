using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceXInfo.Controllers;
using System.Threading.Tasks;
using SpaceXInfo.Repositories;
using Microsoft.Extensions.Logging;
using SpaceXInfo.Models;
using System.Collections.Generic;

namespace SpaceXInfoTest
{
    [TestClass]
    public class SpaceXInfoTests 
    {    
        private readonly ISpaceXRepository repo = new SpaceXRepository();
        private readonly ILoggerFactory logger = new LoggerFactory();


        [TestMethod]
        public async Task TestGetSuccess()
        {        

            SpaceXController spx = new SpaceXController(repo, logger);
            IEnumerable<LaunchPad> pads = await spx.Get();
            bool hasValue = false;
            foreach(var p in pads)
            {
                hasValue = true;
            }
            Assert.IsTrue(hasValue);
        }
       
        [TestMethod]
        public async Task TestGetByLaunchNameSuccess()
        {
            string launchPadName = "ksc_lc_39a";
            SpaceXController spx = new SpaceXController(repo, logger);
            LaunchPad pad = await spx.Get(launchPadName);           
            Assert.IsTrue(pad.Id == launchPadName);
        }

        [TestMethod]
        public async Task TestGetByLaunchNameFailure()
        {
            string launchPadName = "area_51";
            SpaceXController spx = new SpaceXController(repo, logger);
            LaunchPad pad = await spx.Get(launchPadName);
            Assert.IsFalse(pad.Id == launchPadName);
        }
    }
}

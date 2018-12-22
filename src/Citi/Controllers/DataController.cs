using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Citi.Data;
using Microsoft.AspNetCore.Mvc;

namespace Citi.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly DataProcessor _dataProcessor;

        public DataController(DataProcessor dataProcessor)
        {
            _dataProcessor = dataProcessor;
        }

        [HttpGet("[action]")]
        public IEnumerable<PositionLevelRisk> GetPositions()
        {
            return _dataProcessor.GetPositions();
        }
    }
}
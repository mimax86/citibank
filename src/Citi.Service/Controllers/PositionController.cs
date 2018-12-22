using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Citi.Service.Data;
using Citi.Service.Data.Positions;

namespace Citi.Service.Controllers
{
    [Route("api/[controller]")]
    public class PositionController : Controller
    {
        private readonly PositionService _positionService;

        public PositionController(PositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        public IEnumerable<PositionItem> GetPositions()
        {
            return _positionService.GetPositions();
        }
    }
}
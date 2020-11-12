using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactifyAPI.BL.Interfaces;
using Shared.Models;

namespace ReactifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicatorsController : ControllerBase
    {
        private readonly IIndicatorsService _service;

        public IndicatorsController(IIndicatorsService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetRecordsByProductId")]
        public async Task<ActionResult<List<Indicators>>> GetRecordsByProductId(int productId)
        {
            return await _service.GetRecordsByProductId(productId);
        }

        [HttpGet]
        [Route("getIndicatorsInfoList")]
        public async Task<List<IndicatorsInfo>> GetIndicatorsInfoList(int productId)
        {
            return await _service.GetIndicatorsInfoList(productId);
        }

        [HttpGet()]
        [Route("GetAvarageValuesForEachParameter")]
        public async Task<AverageResponse> GetAvarageValuesForEachParameter(int productId)
        {
            return await _service.GetAvarageValuesForEachParameter(productId);
        }

        [HttpGet(/*"{id}"*/)]
        [Route("GetDeviations")]
        public async Task<Deviation> GetDeviations(int productId)
        {
            return await _service.GetDeviations(productId);
        }

        [HttpGet(/*"{id}"*/)]
        [Route("GetEmotionalReaction")]
        public async Task<EmotionModel> GetEmotionalReaction(int productId)
        {
            return await _service.GetEmotionalReaction(productId);
        }
    }
}

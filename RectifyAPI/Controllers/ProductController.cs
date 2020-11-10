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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAllProduct")]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return await _service.GetAllProducts();
        }

        [HttpGet(/*"{id}"*/)]
        [Route("getProductById")]
        public async Task<ActionResult<Product>> GetOne(int id)
        {
            return await _service.GetProduct(id);
        }

        [HttpPut]
        public async Task<ActionResult<Product>> Update(Product entity)
        {
            return await _service.UpdateProduct(entity);
        }

        [HttpDelete(/*"{id}"*/)]
        [Route("deleteProduct")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            return await _service.DeleteProduct(id);
        }

        [HttpGet(/*"{id}"*/)]
        [Route("getIndicatorsByProductId")]
        public async Task<ActionResult<List<Indicators>>> GetIndicatorsByProductId(int productId)
        {
            return await _service.GetIndicatorsByProductId(productId);
        }

        [HttpGet(/*"{id}"*/)]
        [Route("getIndicatorsInfoList")]
        public async Task<List<IndicatorsInfo>> GetIndicatorsInfoList(int productId)
        {
            return await _service.GetIndicatorsInfoList(productId);
        }

        [HttpGet(/*"{id}"*/)]
        [Route("GetAvarageValuesForEachParameter")]
        public async Task<AverageResponse> GetAvarageValuesForEachParameter(int productId)
        {
            return await _service.GetAvarageValuesForEachParameter(productId);
        }

        [HttpGet(/*"{id}"*/)]
        [Route("CompareWithStartValue")]
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

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
    public class TesterUsersController : ControllerBase
    {
        private readonly ITesterUserService _service;

        public TesterUsersController(ITesterUserService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult<TesterUser>> Create(TesterUser entity)
        {
            return await _service.CreateTesterUser(entity);
        }

        [HttpGet]
        [Route("getAllTesterUsers")]
        public async Task<ActionResult<List<TesterUser>>> Get()
        {
            return await _service.GetAllTesterUsers();
        }

        [HttpGet(/*"{id}"*/)]
        [Route("getTesterUsersById")]
        public async Task<ActionResult<TesterUser>> GetOne(int id)
        {
            return await _service.GetTesterUser(id);
        }

        [HttpPut]
        public async Task<ActionResult<TesterUser>> Update(TesterUser entity)
        {
            return await _service.UpdateTesterUser(entity);
        }

        [HttpDelete(/*"{id}"*/)]
        [Route("deleteTesterUsers")]
        public async Task<ActionResult<TesterUser>> Delete(int id)
        {
            return await _service.DeleteTesterUser(id);
        }
    
        [HttpGet(/*"{id}"*/)]
        [Route("GetAvgOfFirstIndicatorValues")]
        public async Task<FirstAvgIndicatorValues> GetAvgOfFirstIndicatorValues(int productId)
        {
            return await _service.GetAvgOfFirstIndicatorValues(productId);
        }
    }
}

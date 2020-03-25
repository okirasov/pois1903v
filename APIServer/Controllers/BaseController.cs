using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIServer.DTO;
using APIServer.Interfaces;
using APIServer.Services;

namespace APIServer.Controllers
{
    public class BaseController<DTO> : ControllerBase
    {
        protected readonly IBaseService<DTO> _baseService;

        public BaseController(IBaseService<DTO> service)
        {
            _baseService = service;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<DTO>> GetAsync()
        {
            return await _baseService.Get();
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _baseService.Get(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _baseService.CreateOrUpdate(dto);

            if (result)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _baseService.Delete(id);
            if (result)
                return Ok();
            else
                return NotFound();
        }

    }
}

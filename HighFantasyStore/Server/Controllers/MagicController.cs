using HighFantasyStore.Server.Services.Magics;
using HighFantasyStore.Shared.Models.Magics;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighFantasyStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagicController : ControllerBase
    {
        private readonly IMagicServices _magicServices;

        public MagicController(IMagicServices magicServices)
        {
            _magicServices = magicServices;
        }


        // GET: api/<MagicController>
        [HttpGet]
        public async Task<List<MagicListItem>> Index()
        {
            var magic = await _magicServices.GetAllMagicAsync();
            return magic.ToList();
        }

        // GET api/<MagicController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Magic(int id)
        {
           var magic = await _magicServices.GetMagicByIdAsync(id);
            if (magic == null) return NotFound();
            return Ok(magic);
        }

        // POST api/<MagicController>
        [HttpPost]
        public async Task<IActionResult> CreateMagic(MagicCreate magic)
        {
            if (magic == null) return BadRequest();
            bool wasSuccesful = await _magicServices.CreateMagicAsync(magic);
            if (wasSuccesful) return Ok();
            else return UnprocessableEntity();
        }

        // PUT api/<MagicController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(MagicEdit magic)
        {
            if(magic == null) return BadRequest();
            bool wasSuccesful = await _magicServices.UpdateMagicAsync(magic);
            if(wasSuccesful) return Ok();
            return BadRequest();
        }

        // DELETE api/<MagicController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var magic = _magicServices.GetMagicByIdAsync(id);
            if(magic == null) return NotFound();
            bool wasSuccesful = await _magicServices.DeleteMagicAsync(id);
            if (!wasSuccesful) return BadRequest();
            return Ok();
        }
    }
}

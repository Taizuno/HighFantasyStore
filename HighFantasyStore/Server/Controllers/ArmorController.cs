using HighFantasyStore.Server.Services.Armors;
using HighFantasyStore.Shared.Models.Armors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighFantasyStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmorController : ControllerBase
    {
        private readonly IArmorServices _ArmorServices;

        public ArmorController(IArmorServices ArmorServices)
        {
            _ArmorServices = ArmorServices;
        }


        // GET: api/<ArmorController>
        [HttpGet]
        public async Task<List<ArmorListItem>> Index()
        {
            var Armor = await _ArmorServices.GetAllArmorAsync();
            return Armor.ToList();
        }

        // GET api/<ArmorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Armor(int id)
        {
            var Armor = await _ArmorServices.GetArmorByIdAsync(id);
            if (Armor == null) return NotFound();
            return Ok(Armor);
        }

        // POST api/<ArmorController>
        [HttpPost]
        public async Task<IActionResult> CreateArmor(ArmorCreate Armor)
        {
            if (Armor == null) return BadRequest();
            bool wasSuccesful = await _ArmorServices.CreateArmorAsync(Armor);
            if (wasSuccesful) return Ok();
            else return UnprocessableEntity();
        }

        // PUT api/<ArmorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(ArmorEdit Armor)
        {
            if (Armor == null) return BadRequest();
            bool wasSuccesful = await _ArmorServices.UpdateArmorAsync(Armor);
            if (wasSuccesful) return Ok();
            return BadRequest();
        }

        // DELETE api/<ArmorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Armor = _ArmorServices.GetArmorByIdAsync(id);
            if (Armor == null) return NotFound();
            bool wasSuccesful = await _ArmorServices.DeleteArmorAsync(id);
            if (!wasSuccesful) return BadRequest();
            return Ok();
        }
    }
}
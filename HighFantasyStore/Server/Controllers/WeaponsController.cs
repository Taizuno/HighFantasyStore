using HighFantasyStore.Server.Services.Weapons;
using HighFantasyStore.Shared.Models.Weapons;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighFantasyStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponsServices _weaponServices;

        public WeaponController(WeaponsServices weaponServices)
        {
            _weaponServices = weaponServices;
        }


        // GET: api/<WeaponController>
        [HttpGet]
        public async Task<List<WeaponsListItem>> Index()
        {
            var Weapon = await _weaponServices.GetAllWeaponsAsync();
            return Weapon.ToList();
        }

        // GET api/<WeaponController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Weapon(int id)
        {
            var Weapon = await _weaponServices.GetWeaponsByIdAsync(id);
            if (Weapon == null) return NotFound();
            return Ok(Weapon);
        }

        // POST api/<WeaponController>
        [HttpPost]
        public async Task<IActionResult> CreateWeapon(WeaponCreate Weapon)
        {
            if (Weapon == null) return BadRequest();
            bool wasSuccesful = await _weaponServices.CreateWeaponsAsync(Weapon);
            if (wasSuccesful) return Ok();
            else return UnprocessableEntity();
        }

        // PUT api/<WeaponController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(WeaponsEdit Weapon)
        {
            if (Weapon == null) return BadRequest();
            bool wasSuccesful = await _weaponServices.UpdateWeaponAsync(Weapon);
            if (wasSuccesful) return Ok();
            return BadRequest();
        }

        // DELETE api/<WeaponController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Weapon = _weaponServices.GetWeaponsByIdAsync(id);
            if (Weapon == null) return NotFound();
            bool wasSuccesful = await _weaponServices.DeleteWeaponAsync(id);
            if (!wasSuccesful) return BadRequest();
            return Ok();
        }
    }
}
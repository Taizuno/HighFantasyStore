using HighFantasyStore.Server.Services.Profiles;
using HighFantasyStore.Shared.Models.profiles;
using HighFantasyStore.Shared.Models.Profiles;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighFantasyStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileServices _ProfileServices;

        public ProfileController(IProfileServices ProfileServices)
        {
            _ProfileServices = ProfileServices;
        }
        private string GetUserId()
        {
            string userIdClaim = User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            if(userIdClaim == null) return null;
            return userIdClaim;
        }
        private bool SetUserIdInService()
        {
            var UserId = GetUserId();
            if (UserId == null) return false;
            _ProfileServices.SetUserId(UserId);
            return true;
        }

        // GET: api/<ProfileController>
        [HttpGet]
        public async Task<List<ProfileListItem>> Index(int UserId)
        {
            var Profile = await _ProfileServices.GetProfilesByOwnerAsync(UserId);
            return Profile.ToList();
        }

        // GET api/<ProfileController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Profile(int id)
        {
            var Profile = await _ProfileServices.GetProfileByIdAsync(id);
            if (Profile == null) return NotFound();
            return Ok(Profile);
        }

        // POST api/<ProfileController>
        [HttpPost]
        public async Task<IActionResult> CreateProfile(ProfileCreate Profile)
        {
            if (Profile == null) return BadRequest();
            bool wasSuccesful = await _ProfileServices.CreateProfileAsync(Profile);
            if (wasSuccesful) return Ok();
            else return UnprocessableEntity();
        }

        // PUT api/<ProfileController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(ProfileEdit Profile)
        {
            if (Profile == null) return BadRequest();
            bool wasSuccesful = await _ProfileServices.UpdateProfileAsync(Profile);
            if (wasSuccesful) return Ok();
            return BadRequest();
        }

        // DELETE api/<ProfileController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Profile = _ProfileServices.GetProfileByIdAsync(id);
            if (Profile == null) return NotFound();
            bool wasSuccesful = await _ProfileServices.DeleteProfileAsync(id);
            if (!wasSuccesful) return BadRequest();
            return Ok();
        }
    }
}
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using ContractorsIdentified.Models;
using ContractorsIdentified.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContractorsIdentified.Controllers
{
  [ApiController]
  [Route("profile")]

  public class ProfileController : ControllerBase
  {
    private readonly ProfileService _ps;

    public ProfileController(ProfileService ps)
    {
      _ps = ps;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using ContractorsIdentified.Models;
using ContractorsIdentified.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContractorsIdentified.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class ContractorController : ControllerBase
  {
    private readonly ContractorService _cs;

    public ContractorController(ContractorService cs)
    {
      _cs = cs;
    }

    [HttpGet("{profileId}/contractors")]
    [Authorize]
    public async Task<ActionResult<Contractor>> Get(string profileId)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_cs.GetContractor(profileId, userInfo));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Contractor>> Create([FromBody] Contractor newContractor)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newContractor.CreatorId = userInfo.Id;
        Contractor created = _cs.Create(newContractor);
        return Ok(created);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
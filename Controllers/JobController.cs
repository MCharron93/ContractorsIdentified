using System.Collections.Generic;
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
  public class JobController : ControllerBase
  {
    private readonly JobService _js;

    public JobController(JobService js)
    {
      _js = js;
    }

    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<Job>> Get()
    {
      try
      {
        return Ok(_js.GetAllJobs());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Job> CreateJob([FromBody] Job newJob)
    {
      try
      {
        Job created = _js.CreateJob(newJob);
        return Ok(created);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
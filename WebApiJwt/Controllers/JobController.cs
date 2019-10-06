using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using WebApiJwt.Data;
using WebApiJwt.Models;
using WebApiJwt.Services;

namespace WebApiJwt.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        //GET api/job/all
        [Authorize(Roles = Role.Administrator + "," + Role.Manager)]
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            try
            {
                //Get ClaimTypes Name
                //string name = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;

                //Get ClaimTypes Roles
                //IEnumerable<string> roles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(s => s.Value);



                //Example of conditional display according to the role
                List<Job> jobs = new List<Job>();

                if (User.IsInRole(Role.Administrator))
                    jobs.Add(_jobService.GetAll().FirstOrDefault());
                else
                    jobs = _jobService.GetAll();


                return Ok(jobs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //GET api/job/1BF21D38-1B58-40F0-B39D-23B90E13E0C1
        [Authorize(Roles = Role.Customer)]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid? id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                Job job = _jobService.GetById(id);

                if (job == null)
                    return NotFound();

                return Ok(job);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
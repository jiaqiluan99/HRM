using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recruiting.API.Controllers
{
    [Route("api/[controller]")]
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;
        private readonly IDistributedCache _cache;

        public JobsController(IJobService jobService, IDistributedCache cache)
        {
            _jobService = jobService;
            _cache = cache;
        }

        // http:localhost/api/jobs
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobs();

            if (!jobs.Any())
                // no jobs exists, then 404
                return NotFound(new { error = "No open Jobs found, please try later" });
            // return Json data, and also HTTP status codes
            // serialization C# objects into Json Objects using System.Text.Json
            return Ok(jobs);
        }

        // http:localhost/api/jobs/4
        [HttpGet]
        [Route("{id:int}", Name = "GetJobDetails")]
        public async Task<IActionResult> GetJobDetails(int id)
        {
            //Angular video, Part 2
            //string newKey = id.ToString();
            //byte[] value = await _cache.GetAsync(newKey);
            //if (value == null) {
            //    var job = await _jobService.GetJobById(id);
            //    value = Encoding.UTF8.GetBytes(job.Title);
            //    await _cache.GetAsync(newKey, value);
            //}
            //var result = Encoding.UTF8.GetString(value);

            var job = await _jobService.GetJobById(id);
            if (job == null) return NotFound(new { errorMessage = "No Job found for this id " });

            return Ok(job);
        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(JobRequestModel model)
        {
            if (!ModelState.IsValid)
                // 400 status code
                return BadRequest();

            var job = await _jobService.AddJob(model);
            return CreatedAtAction
                ("GetJobDetails", new { controller = "Jobs", id = job }, "Job Created");
        }
    }
}


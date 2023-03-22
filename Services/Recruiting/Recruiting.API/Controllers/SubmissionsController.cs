using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recruiting.API.Controllers
{
    [Route("api/[controller]")]
    public class SubmissionsController : Controller
    {
        private readonly IJobService _jobService;
        private readonly ISubmissionService _submissionService;
        public SubmissionsController(IJobService jobService, ISubmissionService submissionService)
        {
            _jobService = jobService;
            _submissionService = submissionService;
        }

        // http:localhost/api/jobs/4
        [HttpGet]
        [Route("{id:int}", Name = "GetSubmissionDetails")]
        public async Task<IActionResult> GetSubmissionDetails(int id)
        {
            var submission = await _submissionService.GetSubmissionById(id);
            if (submission == null) return NotFound(new { errorMessage = "No Job found for this id " });

            return Ok(submission);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(SubmissionRequestModel model)
        {
            // check if the model is valid, on the server
            bool cond = await _submissionService.EmailExisted(model.Email);
            if (!ModelState.IsValid || cond)
                // 400 status code
                return BadRequest();

            var submission = await _submissionService.AddSubmission(model);
            return CreatedAtAction
                ("GetSubmissionDetails", new { controller = "Submissions", id = submission }, "Submission Created");
        }
    }
}


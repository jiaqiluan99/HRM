using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecruitingWeb.Controllers
{
    public class SubmissionsController : Controller
    {

        private readonly IJobService _jobService;
        private readonly ISubmissionService _submissionService;
        public SubmissionsController(IJobService jobService, ISubmissionService submissionService)
        {
            _jobService = jobService;
            _submissionService = submissionService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            // get job by Id
            var job = await _jobService.GetJobById(id);
            var submission = new SubmissionRequestWebModel
            {
                JobCode = job.JobCode,
                Title = job.Title,
                JobId = job.Id
            };
            return View(submission);
        }

        // Saving the Submission Information
        [HttpPost]
        public async Task<IActionResult> Create(SubmissionRequestWebModel model)
        {
            // check if the model is valid, on the server
            bool cond = await _submissionService.EmailExisted(model.Email);
            if (!ModelState.IsValid || cond)
            {
                return View(model);
            }
            // save the data in database
            // return to the index view
            await _submissionService.AddSubmission(model);
            return RedirectToAction("Index", "Jobs");
        }
    }
}


using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;
        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        public async Task<IActionResult> Index()
        {
            var jobs = await _jobService.GetAllJobs();
            return View(jobs);
        }

        public async Task<IActionResult> Details(int id)
        {
            // get job by Id
            var job = await _jobService.GetJobById(id);
            return View(job);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Saving the Job Information
        [HttpPost]
        public async Task<IActionResult> Create(JobRequestModel model)
        {
            // check if the model is valid, on the server
            if (!ModelState.IsValid)
            {
                return View();
            }
            // save the data in database
            // return to the index view
            await _jobService.AddJob(model);
            return RedirectToAction("Index");
        }
    }
}



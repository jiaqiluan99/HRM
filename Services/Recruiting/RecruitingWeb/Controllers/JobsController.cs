using ApplicationCore.Contracts.Services;
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

        public IActionResult Create()
        {
            return View();
        }
    }
}


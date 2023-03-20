using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;

    public JobService(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task<List<JobResponseModel>> GetAllJobs()
    {
        var jobs = await _jobRepository.GetAllJobs();

        var jobsResponseModel = new List<JobResponseModel>();

        foreach (var job in jobs)
            jobsResponseModel.Add(new JobResponseModel
            {
                Id = job.Id,
                Description = job.Description,
                Title = job.Title,
                StartDate = job.StartDate.GetValueOrDefault(),
                NumberOfPositions = job.NumberOfPositions
            });

        return jobsResponseModel;
    }

    public async Task<JobResponseModel> GetJobById(int id)
    {
        var job = await _jobRepository.GetJobById(id);
        var jobResponseModel = new JobResponseModel
        {
            Id = job.Id,
            Title = job.Title,
            StartDate = job.StartDate.GetValueOrDefault(),
            Description = job.Description
        };
        return jobResponseModel;
    }
}


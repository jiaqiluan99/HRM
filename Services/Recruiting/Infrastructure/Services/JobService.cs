using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
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
                JobCode = job.JobCode,
                NumberOfPositions = job.NumberOfPositions,
                Title = job.Title,
                Description = job.Description,
                StartDate = job.StartDate.GetValueOrDefault(),
                
            });

        return jobsResponseModel;
    }

    public async Task<JobResponseModel> GetJobById(int id)
    {
        var job = await _jobRepository.GetJobById(id);
        var jobResponseModel = new JobResponseModel
        {
            Id = job.Id,
            JobCode = job.JobCode,
            NumberOfPositions = job.NumberOfPositions,
            Title = job.Title,
            StartDate = job.StartDate.GetValueOrDefault(),
            Description = job.Description,
            IsActive = job.IsActive,
            CreatedOn = job.CreatedOn
        };
        return jobResponseModel;
    }

    public async Task<int> AddJob(JobRequestModel model)
    {
        // call the repository that will use EF Core to save the data
        var jobEntity = new Job
        {
            Title = model.Title,
            StartDate = model.StartDate,
            Description = model.Description,
            CreatedOn = DateTime.UtcNow,
            NumberOfPositions = model.NumberOfPositions,
            JobStatusLookUpId = 1,
            IsActive = true
        };

        var job = await _jobRepository.AddAsync(jobEntity);
        return job.Id;
    }
}


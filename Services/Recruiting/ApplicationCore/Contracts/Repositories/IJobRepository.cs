using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllJobs();

        Task<Job> GetJobById(int id);
    }
}


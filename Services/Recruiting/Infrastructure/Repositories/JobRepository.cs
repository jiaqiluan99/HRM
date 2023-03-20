using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Repositories;

public class JobRepository : Repository<Job>, IJobRepository
{
    public JobRepository(RecruitingDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Job>> GetAllJobs()
    {
        // go to the database and get the data
        // EF Core with LINQ 
        var jobs = await _dbContext.Jobs.ToListAsync();
        return jobs;
    }

    public async Task<Job> GetJobById(int id)
    {
        var job = await _dbContext.Jobs.FirstOrDefaultAsync(j => j.Id == id);
        return job;
    }
}


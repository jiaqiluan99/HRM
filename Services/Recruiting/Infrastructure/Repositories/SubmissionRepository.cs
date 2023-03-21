using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Repositories
{
	public class SubmissionRepository : Repository<Submission>, ISubmissionRepository
	{
        public SubmissionRepository(RecruitingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> EmailExisted(string email)
        {
            bool cond = await _dbContext.Candidates.AnyAsync<Candidate>(c => c.Email == email);
            return cond;
        }
    }
}


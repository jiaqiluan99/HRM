using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
namespace Infrastructure.Repositories
{
	public class CandidateRepository : Repository<Candidate>, ICandidateRepository
	{
        public CandidateRepository(RecruitingDbContext dbContext) : base(dbContext)
        {
        }
    }
}


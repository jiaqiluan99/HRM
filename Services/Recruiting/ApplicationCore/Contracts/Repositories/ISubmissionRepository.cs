using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
	public interface ISubmissionRepository : IRepository<Submission>
    {

        public Task<Boolean> EmailExisted(string email);
        public Task<Submission> GetSubmissionById(int id);

    }

    
}


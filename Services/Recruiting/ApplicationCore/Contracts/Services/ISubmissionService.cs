using System;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface ISubmissionService
	{
        Task<bool> EmailExisted(string email);
        Task<int> AddSubmission(SubmissionRequestModel model);
        public Task<SubmissionResponseModel> GetSubmissionById(int id);
    }
}


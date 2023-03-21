using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Repositories;
using System;
namespace Infrastructure.Services
{
	public class SubmissionService : ISubmissionService
	{
        private readonly ISubmissionRepository _submissionRepository;
        private readonly ICandidateRepository _candidateRepository;

        public SubmissionService(ISubmissionRepository submissionRepository, ICandidateRepository candidateRepository)
        {
            _submissionRepository = submissionRepository;
            _candidateRepository = candidateRepository;
        }



        public async Task<int> AddSubmission(SubmissionRequestModel model)
        {
            // call the repository that will use EF Core to save the data

            var candidateEntity = new Candidate
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                CreatedOn = DateTime.UtcNow
            };

            var candidate = await _candidateRepository.AddAsync(candidateEntity);

            var submissionEntity = new Submission
            {
                CandidateId = candidate.Id,
                JobId = model.JobId
            };

            var submission = await _submissionRepository.AddAsync(submissionEntity);
            return submission.Id;
        }

        public async Task<bool> EmailExisted(string email)
        {
            bool cond = await _submissionRepository.EmailExisted(email);
            return cond;
        }
    }
}


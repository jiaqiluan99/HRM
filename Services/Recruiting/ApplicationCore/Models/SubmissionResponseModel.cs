using System;
namespace ApplicationCore.Models
{
	public class SubmissionResponseModel
	{
        public int Id { get; set; }

        public int JobId { get; set; }
        public int CandidateId { get; set; }
        public DateTime? SubmittedOn { get; set; }
    }
}


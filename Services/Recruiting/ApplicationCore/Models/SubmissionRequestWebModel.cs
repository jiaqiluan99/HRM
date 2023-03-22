using System;
namespace ApplicationCore.Models
{
	public class SubmissionRequestWebModel : SubmissionRequestModel
	{
        public Guid JobCode { get; set; }
        public string Title { get; set; }
    }
}


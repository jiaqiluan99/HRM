using System;
namespace ApplicationCore.Entities;

public class Submission
{
    public int Id { get; set; }

    public int JobId { get; set; }
    public int CandidateId { get; set; }
    public DateTime? SubmittedOn { get; set; }
    public DateTime? SelectedForInterview { get; set; }
    public DateTime? RejectedOn { get; set; }
    public string RejectedReason { get; set; }

    public Job Job { get; set; }
    public Candidate Candidate { get; set; }
}


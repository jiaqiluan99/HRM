

using System.ComponentModel.DataAnnotations;
using Interviews.ApplicationCore.Constants;
using Interviews.ApplicationCore;

namespace Interviews.ApplicationCore.Entities;

public class Interview
{
    public int Id { get; set; }
    public int InterviewerId { get; set; }
    public int InterviewTypeId { get; set; }
    public Guid CandidateIdentityId { get; set; }

    [MaxLength(50)]
    public string CandidateFirstName { get; set; }
    [MaxLength(50)]
    public string CandidateLastName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    [MaxLength(2048)]
    public string CandidateEmail { get; set; }
    public int SubmissionId { get; set; }
    public DateTime BeginTime { get; set; }
    public DateTime EndTime { get; set; }
    public Rating? Rating { get; set; }

    public string? Feedback { get; set; }
    public bool? Passed { get; set; }

    //Navigation properties
    public Interviewer Interviewer { get; set; }
    public InterviewTypeLookUp InterviewType { get; set; }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Job
{
    // PK
    public int Id { get; set; }
    public Guid JobCode { get; set; }

    [MaxLength(80)]
    public string Title { get; set; }

    [MaxLength(2048)]
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public bool? IsActive { get; set; }
    public int NumberOfPositions { get; set; }
    public DateTime? ClosedOn { get; set; }

    [MaxLength(1024)]
    public string? ClosedReason { get; set; }
    public DateTime? CreatedOn { get; set; }

    public int JobStatusLookUpId { get; set; }

    // Navigation property in EF
    public JobStatusLookUp JobStatusLookUp { get; set; }
}


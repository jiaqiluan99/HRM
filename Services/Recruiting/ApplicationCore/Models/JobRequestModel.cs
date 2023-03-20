using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class JobRequestModel
{
    public int Id { get; set; }

    [StringLength(256)]
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public int NumberOfPositions { get; set; }

}


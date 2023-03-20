using System;

namespace ApplicationCore.Models;
public class JobResponseModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public DateTime StartDate { get; set; }
    public int NumberOfPositions { get; set; }
}


using System;
namespace ApplicationCore.Entities;

public class JobStatusLookUp
{
    // Open, Pending, Closed,Postponed 
    public int Id { get; set; }
    public string JobStatusCode { get; set; }
    public string JobStatusDescription { get; set; }
}


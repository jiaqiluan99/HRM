using System;
using Interviews.ApplicationCore.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Interviews.Infrastructure.Data
{
    public class InterviewsDbContext : DbContext
    {
        public InterviewsDbContext(DbContextOptions<InterviewsDbContext> options) : base(options)
        {
        }

        public DbSet<Interviewer> Interviewers { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<InterviewTypeLookUp> InterviewTypeLookUps { get; set; }
    }
}


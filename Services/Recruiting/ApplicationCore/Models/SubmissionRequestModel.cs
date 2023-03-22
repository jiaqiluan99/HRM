using System;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;

namespace ApplicationCore.Models
{
	public class SubmissionRequestModel
	{
        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [StringLength(512)]
        public string Email { get; set; }

        public int JobId { get; set; }
    }
}


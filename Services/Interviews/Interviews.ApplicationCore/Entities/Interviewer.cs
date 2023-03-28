using System;
using System.ComponentModel.DataAnnotations;

namespace Interviews.ApplicationCore.Entities
{
	public class Interviewer
	{
        public int Id { get; set; }

        [MaxLength(50)] public string FirstName { get; set; }

        [MaxLength(50)] public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [MaxLength(2048)]
        public string Email { get; set; }

        public Guid EmployeeIdentityId { get; set; }
    }
}


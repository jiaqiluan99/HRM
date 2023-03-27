using System;
using Microsoft.AspNetCore.Identity;
namespace Authentication.API.Entities
{
	public class Role : IdentityRole<Guid>
	{
		public ICollection<UserRole> UsersForRole { get; set; }
	}
}


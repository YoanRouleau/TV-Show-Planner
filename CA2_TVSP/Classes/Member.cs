using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_TVSP.Classes
{
    public abstract class Member
    {
		private String firstName;
		private String lastName;
		private DateTime dateOfBirth;
		private String role;


		public Member(String pFirstName, String pLastName, DateTime pDateOfBirth, String pRole)
		{
			this.FirstName = pFirstName;
			this.LastName = pLastName;
			this.DateOfBirth = pDateOfBirth;
			this.Role = pRole;
		}

		public Member() { }

		public String FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}

		public String LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}

		public DateTime DateOfBirth
		{
			get { return dateOfBirth; }
			set { dateOfBirth = value; }
		}

		public String Role
		{
			get { return role; }
			set { role = value; }
		}

	}
}

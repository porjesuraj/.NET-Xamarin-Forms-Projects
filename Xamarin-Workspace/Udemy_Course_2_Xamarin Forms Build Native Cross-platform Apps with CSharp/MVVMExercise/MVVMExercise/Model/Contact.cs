using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using SQLite;
namespace MVVMExercise.Model
{
	public class Contact 
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[MaxLength(255)]
		public string FirstName { get; set; }

		[MaxLength(255)]
		public string LastName { get; set; }

		[MaxLength(255)]
		public string Phone { get; set; }

		[MaxLength(255)]
		public string Email { get; set; }

		public bool Blocked { get; set; }
	}
}
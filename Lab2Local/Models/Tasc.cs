using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2Local.Models
{
	public class Tasc
	{
		public enum Importance
		{
			Low,
			Medium ,
			High 
		}

		public enum State
		{
			Open,
			InProgress,
			Closed
		}

		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Added { get; set; }
		public DateTime Deadline { get; set; }

		[EnumDataType(typeof(Importance))]
		public Importance Important { get; set; }
		[EnumDataType(typeof(State))]
		public State Stare { get; set; }
		public Nullable<DateTime> ClosedAt { get; set; }
		//public List<Comment> Comments { get; set; }

	}

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2Local.Models
{
	public class TasksDbSeeder
	{
		public static void Initialize(TasksDbContext context)
		{
			context.Database.EnsureCreated();

			
			if (context.TasksNou.Any())
			{
				return;   // DB has been seeded
			}

			context.TasksNou.AddRange(
				new Tasc
				{
					Title = "Sleep",
					Description = "Sleep",
					Added = DateTime.Parse("2019-01-28"),
					Deadline = DateTime.Parse("2019-10-10"),
					Important = 0,
					Stare = 0,
					ClosedAt = DateTime.Parse("2019-06-17") 
				},
				new Tasc
				{
					Title = "Eat",
					Description = "Eat",
					Added = DateTime.Parse("2019-02-29"),
					Deadline = DateTime.Parse("2019-07-10"),
					Important = 0,
					Stare = 0,
					ClosedAt = DateTime.Parse("2019-06-17")
				}
			);
			context.SaveChanges();
		}
	}
}


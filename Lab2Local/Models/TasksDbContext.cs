using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2Local.Models
{
	public class TasksDbContext : DbContext
	{
				
			public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options)
			{
			}

			// DbSet = Repository
			// DbSet = O tabela din baza de date
			public DbSet<Tasc> TasksNou { get; set; }
			//public DbSet<Comment> Comments { get; set; }
		}
	}


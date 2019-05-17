using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2Local.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2Local.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TasksController : ControllerBase

	{
		private TasksDbContext context;
		public TasksController(TasksDbContext context)
		{
			this.context = context;
		}


		// GET: api/Tasks
		[HttpGet("/tasc")]
		public IEnumerable<Tasc> Get([FromQuery]DateTime? from,[FromQuery]DateTime? to)
		{
			IQueryable<Tasc> result = context.TasksNou;

			if (from == null && to == null)
			{
				return result;
			}
			
		
			if (from != null)
			{
				result = result.Where(t => t.Added >= from);
			}
			if (to != null)
			{
				result = result.Where(t => t.Added <= to);
			}
			return result;
		}

		// GET: api/Tasks/5
		[HttpGet("{id}", Name = "Get")]
		public IActionResult Get(int id)
		{
			var existing = context.TasksNou.FirstOrDefault(Tasc => Tasc.Id == id);
			if (existing == null)
			{
				return NotFound();
			}

			return Ok(existing);
		}


		// POST: api/Tasks
		[HttpPost]
		public void Post([FromBody] Tasc tasc)
		{
		
			context.TasksNou.Add(tasc);
			context.SaveChanges();
		}

		// PUT: api/Tasks/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Tasc tasc)
		{
			var existing = context.TasksNou.AsNoTracking().FirstOrDefault(t => t.Id == id);

			if (existing == null)
			{
				context.TasksNou.Add(tasc);
				context.SaveChanges();
				return Ok(tasc);
			}
			tasc.Id = id;
			//if (tasc.Stare.Equals(Tasc.State.Closed))
			//{
			//	tasc.ClosedAt = DateTime.Now;
			//}
			//else
			//{
			//	tasc.ClosedAt = (DateTime?)null;


			//}


			context.TasksNou.Update(tasc);
			context.SaveChanges();
			return Ok(tasc);
		}


		// DELETE: api/task/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var existing = context.TasksNou.FirstOrDefault(tasc => tasc.Id == id);
			if (existing == null)
			{
				return NotFound();
			}
			context.TasksNou.Remove(existing);
			context.SaveChanges();
			return Ok();
		}
	}
}

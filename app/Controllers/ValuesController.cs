using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using making_unit_tests.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace making_unit_tests.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly IEntityRepository _EntityRepository;

		public ValuesController(IEntityRepository entityRepository)
		{
			_EntityRepository = entityRepository;
		}

		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
			_EntityRepository.DoSomethingWithAValue(value);
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}

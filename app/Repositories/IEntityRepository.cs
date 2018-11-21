using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace making_unit_tests.Repositories
{
	public interface IEntityRepository
	{
		Task DoSomething();

		Task DoSomethingWithAValue(string someUsefulParameter);
	}
}

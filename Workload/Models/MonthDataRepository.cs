using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Workload.Models
{   
	public  class MonthDataRepository : EFRepository<MonthData>, IMonthDataRepository
	{

	}

	public  interface IMonthDataRepository : IRepository<MonthData>
	{

	}
}
using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Workload.Models
{   
	public  class budget_planRepository : EFRepository<budget_plan>, Ibudget_planRepository
	{

	}

	public  interface Ibudget_planRepository : IRepository<budget_plan>
	{

	}
}
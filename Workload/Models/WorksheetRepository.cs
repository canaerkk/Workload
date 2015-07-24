using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Workload.Models
{   
	public  class WorksheetRepository : EFRepository<Worksheet>, IWorksheetRepository
	{

	}

	public  interface IWorksheetRepository : IRepository<Worksheet>
	{

	}
}
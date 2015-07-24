using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Workload.Models
{   
	public  class PrjDataRepository : EFRepository<PrjData>, IPrjDataRepository
	{

	}

	public  interface IPrjDataRepository : IRepository<PrjData>
	{

	}
}
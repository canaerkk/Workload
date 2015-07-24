using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Workload.Models
{   
	public  class V_EmpdataRepository : EFRepository<V_Empdata>, IV_EmpdataRepository
	{

	}

	public  interface IV_EmpdataRepository : IRepository<V_Empdata>
	{

	}
}
using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Workload.Models
{   
	public  class audit_editRepository : EFRepository<audit_edit>, Iaudit_editRepository
	{

	}

	public  interface Iaudit_editRepository : IRepository<audit_edit>
	{

	}
}
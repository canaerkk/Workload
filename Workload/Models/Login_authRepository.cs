using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Workload.Models
{   
	public  class Login_authRepository : EFRepository<Login_auth>, ILogin_authRepository
	{

	}

	public  interface ILogin_authRepository : IRepository<Login_auth>
	{

	}
}
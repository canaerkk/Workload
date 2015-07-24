using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Workload.Models
{   
	public  class WorksheetRepository : EFRepository<Worksheet>, IWorksheetRepository
	{
        public override IQueryable<Worksheet> All()
        {
            return base.All();
        }

        //Get Workload by Prj
        public IQueryable<Worksheet> GetPrj(string prj)
        {
            return this.All().Where(p=>p.Prj==prj && p.V_Empdata1.Status==1);
        }

        public IQueryable<Worksheet> GetYear(string prj)
        {
            var result = this.GetPrj(prj).GroupBy(WYear => WYear.MonthData.Year).Select(group=>group.FirstOrDefault());
            return result;
        }
        public IQueryable<Worksheet> GetMonth(string prj)
        {
            var result = this.GetPrj(prj).GroupBy(WMonth => WMonth.Month).Select(group => group.FirstOrDefault());
            return result;
        }
        public IQueryable<Worksheet> GetEmp(string prj)
        {
            var result = this.GetPrj(prj).GroupBy(WEmp => WEmp.V_Empdata1.EmpID).Select(group => group.FirstOrDefault());
            return result;
        }
        public IQueryable<Worksheet> GetEditor(string prj)
        {
            var result = this.GetPrj(prj).GroupBy(WEditor => WEditor.V_Empdata.EmpID).Select(group => group.FirstOrDefault());
            return result;
        }
      

	}
	
	public  interface IWorksheetRepository : IRepository<Worksheet>
	{

	}
}
using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Workload.Models
{   
	public  class WorksheetRepository : EFRepository<Worksheet>, IWorksheetRepository
	{
        public override IQueryable<Worksheet> All()
        {
            return base.All().Where(p=>p.V_Empdata1.Status==1);
        }

        //Get Workload by Prj
        public IQueryable<Worksheet> GetByPrj(string prj)
        {
            return this.All().Where(p=>p.Prj==prj);
        }
        //Get Workload by Emp
        public IQueryable<Worksheet> GetByEmp(string emp)
        {
            return this.All().Where(p => p.V_Empdata1.EmpID == emp);
        }
        public IQueryable<Worksheet> GetYear(string prj)
        {
            var result = GroupByYear(this.GetByPrj(prj));
            return result;
        }
        public IQueryable<Worksheet> GetMonth(string prj)
        {
            var result = GroupByMonth(this.GetByPrj(prj));
            return result;
        }
        public IQueryable<Worksheet> GetEmp(string prj)
        {
            var result = GroupByEmp(this.GetByPrj(prj));
            return result;
        }
        public IQueryable<Worksheet> GetEditor(string prj)
        {
            var result = GroupByEditor(this.GetByPrj(prj));
            return result;
        }

        //Group By func
        public IQueryable<Worksheet> GroupByYear(IQueryable<Worksheet> queryable)
        {
           return queryable.GroupBy(WYear => WYear.MonthData.Year).Select(group => group.FirstOrDefault());
            
        }
        
        public IQueryable<Worksheet> GroupByMonth(IQueryable<Worksheet> queryable)
        {
            return queryable.GroupBy(WMonth => WMonth.Month).Select(group => group.FirstOrDefault());
        }
        
        public IQueryable<Worksheet> GroupByEmp(IQueryable<Worksheet> queryable)
        {
           return queryable.GroupBy(WEmp => WEmp.V_Empdata1.EmpID).Select(group => group.FirstOrDefault());
        }
        
        public IQueryable<Worksheet> GroupByEditor(IQueryable<Worksheet> queryable)
        {
            return queryable.GroupBy(WEmp => WEmp.V_Empdata.EmpID).Select(group => group.FirstOrDefault());
        }
      

	}
	
	public  interface IWorksheetRepository : IRepository<Worksheet>
	{

	}
}
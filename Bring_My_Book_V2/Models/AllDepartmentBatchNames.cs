using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bring_My_Book_V2.Models
{
    public class AllDepartmentBatchNames
    {
        public List<Department> Alldept = new List<Department>();
        public List<Batch> Allbatch = new List<Batch>();
        public ApplicationDbContext context = new ApplicationDbContext();
        public AllDepartmentBatchNames()
        {
           
        }
        public List<Department> allDeptfunc()
        {
            if (Alldept.Count == 0)
            {
                for (int i = 1; i <= 27; i++)               //Total dept is 27. so loop is going for 27
                {

                    Alldept.Add((from d in context.Departments
                                 where d.DepartmentId == i
                                 select d).First());

                }
            }
            return Alldept;
        }
        public List<Batch> allBatchfunc()
        {
            if (Allbatch.Count == 0)
            {
                for (int i = 1; i <= 26; i++)               //Total batch is 26. so loop is going for 26 (1991-2016)
                {

                    Allbatch.Add((from d in context.Batches
                                  where d.BatchId == i
                                  select d).First());

                }
            }
            return Allbatch;
        }

        
    }
}
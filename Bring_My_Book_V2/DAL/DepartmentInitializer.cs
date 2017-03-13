using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Bring_My_Book_V2.Models;

namespace Bring_My_Book_V2.DAL
{
    public class DepartmentInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
            protected override void Seed(ApplicationDbContext context)
            {
         

                
                var Departments = new List<Department>
                {
                    new Department{DepartmentName = "Chemistry"},
                    new Department{DepartmentName = "Geography and Environment"},
                    new Department{DepartmentName = "Mathematics"},
                    new Department{DepartmentName = "Physics"},
                    new Department{DepartmentName = "Statistics"},
                    new Department{DepartmentName = "Biochemistry and Molecular Biology"},
                    new Department{DepartmentName = "Genetic Engineering and Biotechnology"},
                    new Department{DepartmentName = "Forestry and Environmental Science"},
                    new Department{DepartmentName = "Architechture"},
                    new Department{DepartmentName = "Chemical Engineering and Polymer Science"},
                    new Department{DepartmentName = "Civil and Environmental Engineering"},
                    new Department{DepartmentName = "Computer Science and Engineering"},
                    new Department{DepartmentName = "Electrical and Electronics Engineering"},
                    new Department{DepartmentName = "Food Engineering and Tea Technology"},
                    new Department{DepartmentName = "Industrial and Production Engineering"},
                    new Department{DepartmentName = "Petroleum and Mining Engineering"},
                    new Department{DepartmentName = "Anthropology"},
                    new Department{DepartmentName = "Bangla"},
                    new Department{DepartmentName = "Economics"},
                    new Department{DepartmentName = "English"},
                    new Department{DepartmentName = "Political Studies"},
                    new Department{DepartmentName = "Public Administration"},
                    new Department{DepartmentName = "Social Work"},
                    new Department{DepartmentName = "Sociology"},
                    new Department{DepartmentName = "business Administration"},
                    new Department{DepartmentName = "Software Engineering"},
                    new Department{DepartmentName = "Oceanography"}
                };

                Departments.ForEach(d => context.Departments.Add(d));
                context.SaveChanges();

                var Batches = new List<Batch>
                {
                    new Batch {BatchYear = 1991},
                    new Batch {BatchYear = 1992},
                    new Batch {BatchYear = 1993},
                    new Batch {BatchYear = 1994},
                    new Batch {BatchYear = 1995},
                    new Batch {BatchYear = 1996},
                    new Batch {BatchYear = 1997},
                    new Batch {BatchYear = 1998},
                    new Batch {BatchYear = 1999},
                    new Batch {BatchYear = 2000},
                    new Batch {BatchYear = 2001},
                    new Batch {BatchYear = 2002},
                    new Batch {BatchYear = 2003},
                    new Batch {BatchYear = 2004},
                    new Batch {BatchYear = 2005},
                    new Batch {BatchYear = 2006},
                    new Batch {BatchYear = 2007},
                    new Batch {BatchYear = 2008},
                    new Batch {BatchYear = 2009},
                    new Batch {BatchYear = 2010},
                    new Batch {BatchYear = 2011},
                    new Batch {BatchYear = 2012},
                    new Batch {BatchYear = 2013},
                    new Batch {BatchYear = 2014},
                    new Batch {BatchYear = 2015},
                    new Batch {BatchYear = 2016}
                };

                Batches.ForEach(b => context.Batches.Add(b));
                context.SaveChanges();
            }
    }
}
using Core.DataAccess.Concrete;
using DataAccess.Repositories.Abstract;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class EmployeeRepository:Repository<Employee,AnyarDbContext>,IEmployeeRepository
    {
        public EmployeeRepository(AnyarDbContext context ):base(context) { }
    }
}

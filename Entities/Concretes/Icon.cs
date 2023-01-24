using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Icon:IEntity
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}

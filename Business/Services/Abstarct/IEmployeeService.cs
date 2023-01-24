using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstarct
{
    public interface IEmployeeService
    {
        Task DeleteAsync(int id);
        Task UpdateAsync(EmployeeUpdateDto updateDto);
        Task CreateAsync(EmployeePostDto postDto);
        Task<List<EmployeeGetDto>> GetAllAsync();
        EmployeeGetDto GetById(int id); 


    }
}

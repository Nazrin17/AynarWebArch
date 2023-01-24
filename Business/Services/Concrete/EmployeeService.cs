using AutoMapper;
using Business.Services.Abstarct;
using DataAccess.Repositories.Abstract;
using Entities.Concretes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper, IWebHostEnvironment env)
        {
            _repository = repository;
            _mapper = mapper;
            _env = env;
        }

        public async Task CreateAsync(EmployeePostDto postDto)
        {
            Employee employee = _mapper.Map<Employee>(postDto);
            string imagename = Guid.NewGuid() + postDto.FormFile.FileName;
            string path = Path.Combine(_env.WebRootPath, "assets/img", imagename);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                postDto.FormFile.CopyTo(fileStream);
            }
            employee.Image = imagename;
            foreach (var item in postDto.Icons)
            {
                employee.Icons.Add(item);
            }
            await _repository.CreateAsync(employee);
            await _repository.SaveAsync();

        }

        public async Task DeleteAsync(int id)
        {
            Employee emp = _repository.GetById(id);
            if (emp is null) throw new Exception("Not Found");
            _repository.Delete(emp);
            await _repository.SaveAsync();
        }

        public async Task<List<EmployeeGetDto>> GetAllAsync()
        {
            List<Employee> emps = await _repository.GetAllAsync();
            if (emps is null) throw new Exception("Not Found");
            List<EmployeeGetDto> getDtos = _mapper.Map<List<EmployeeGetDto>>(emps);
            return getDtos;

        }

        public EmployeeGetDto GetById(int id)
        {
            Employee emp = _repository.GetById(id);
            if (emp is null) throw new Exception("Not Found");
            EmployeeGetDto getDto = _mapper.Map<EmployeeGetDto>(emp);
            return getDto;

        }

        public async Task UpdateAsync(EmployeeUpdateDto updateDto)
        {
            Employee employee = _repository.GetById(updateDto.getDto.Id);

            //Employee employee = _context.Employees.Include(e => e.Icons).Where(e => e.Id == updateDto.getDto.Id).FirstOrDefault();
            employee.Position = updateDto.postDto.Position;
            employee.Name = updateDto.postDto.Name;
            employee.About = updateDto.postDto.About;
            if (updateDto.postDto.FormFile != null)
            {
                string imagename = Guid.NewGuid() + updateDto.postDto.FormFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "assets/img", imagename);
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    updateDto.postDto.FormFile.CopyTo(fileStream);
                }
                employee.Image = imagename;
            }
            //for (int i = 0; i < updateDto.postDto.Icons.Count; i++)
            //{
            //    employee.Icons[i] = updateDto.postDto.Icons[i];
            //}
            _repository.Update(employee);
            await _repository.SaveAsync();

        }


    }
}

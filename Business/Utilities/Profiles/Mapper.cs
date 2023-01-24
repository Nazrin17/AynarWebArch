
using AutoMapper;
using Entities.Concretes;

public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Employee,EmployeeGetDto>();
            CreateMap<EmployeePostDto, Employee>();
        }
    }


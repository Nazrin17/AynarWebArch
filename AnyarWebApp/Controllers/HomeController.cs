using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Business.Services.Abstarct;

namespace AnyarWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _service;

        public HomeController(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<EmployeeGetDto> emps = await _service.GetAllAsync();
            return View(emps);
        }

    }
}
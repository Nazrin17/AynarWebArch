using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Concretes;
using Business.Services.Abstarct;

namespace AnyarWebApp.Areas.Area.Controllers
{
    [Area("admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<IActionResult>  Index()
        {
            List<EmployeeGetDto> getDtos = await _service.GetAllAsync();
            return View(getDtos);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeePostDto postDto)
        {


            //if (!ModelState.IsValid)
            //{
            //    foreach (var item in postDto.Icons)
            //    {
            //        if (item.Name == null || item.Url == null)
            //        {
            //            ModelState.AddModelError("Icons", "The Icon field is required.");
            //        }
            //    }
            //    return View();
            //}
           await _service.CreateAsync(postDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
          
            EmployeeUpdateDto updateDto = new EmployeeUpdateDto { getDto = _service.GetById(id)
             };
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(EmployeeUpdateDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid format");
            }
        await _service.UpdateAsync(updateDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
           await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

    }
}

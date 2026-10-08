using Microsoft.AspNetCore.Mvc;
using Panaderia.web.Data.Entities;
using Panaderia.web.DTOs;
using Panaderia.web.Services.Abstractions;
using Panaderia.wed.Services.Abstractios;

namespace Panaderia.web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISuppliersService _suppliersService;

        public SuppliersController(ISuppliersService suppliersService)
        {
            _suppliersService = suppliersService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Supplier> list = await _suppliersService.GetListAsync();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSupplierDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            await _suppliersService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            UpdateSupplierDTO dto = await _suppliersService.GetOneAsync(id);
            return View("Update", dto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSupplierDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            await _suppliersService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _suppliersService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
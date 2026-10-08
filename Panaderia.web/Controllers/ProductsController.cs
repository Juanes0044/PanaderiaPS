using Microsoft.AspNetCore.Mvc;
using Panaderia.web.Data.Entities;
using Panaderia.web.Services.Abstractions;
using Panaderia.web.DTOs;

namespace Panaderia.web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Product> list = await _productsService.GetListAsync();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDTO dto)
        {
            if (!ModelState.IsValid)

            {
                return View(dto);
            }

            await _productsService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            UpdateProductDTO dto = await _productsService.GetOneAsync(id);
            return View ("Update", dto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _productsService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _productsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

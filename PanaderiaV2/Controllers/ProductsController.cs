using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using PanaderiaV2.Web.Core;
using PanaderiaV2.Web.Core.Pagination;
using PanaderiaV2.Web.DTOs;
using PanaderiaV2.Web.DTOs.Product;
using PanaderiaV2.Web.Services.Abstractions;


namespace PanaderiaV2.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly INotyfService _notyfService;
        private readonly IProductsService _ProductsService;

        public ProductsController(INotyfService notyfService, IProductsService ProductsService)
        {
            _notyfService = notyfService;
            _ProductsService = ProductsService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PaginationRequest request)
        {
            Response<PaginationResponse<ProductDTO>> response = await _ProductsService.GetPaginationAsync(request);

            if (!response.IsSuccess)
            {
                _notyfService.Error(response.Message);
                return RedirectToAction("Index", "Home");
            }

            return View(response.Result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductDTO dto)
        {
            if (!ModelState.IsValid)
            {
                _notyfService.Error("Debe ajustar los errores de validación");
                return View(dto);
            }

            Response<CreateProductDTO> response = await _ProductsService.CreateAsync(dto);

            if (!response.IsSuccess)
            {
                _notyfService.Error(response.Message);
                return View(dto);
            }

            _notyfService.Success(response.Message);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            Response<ProductDTO> response = await _ProductsService.GetOneAsync(id);

            if (!response.IsSuccess)
            {
                _notyfService.Error(response.Message);
                return RedirectToAction(nameof(Index));
            }

            UpdateProductDTO dto = new UpdateProductDTO
            {
                Id = response.Result.Id,
                Name = response.Result.Name,
                Description = response.Result.Description,
                price = response.Result.price,
                stock = response.Result.stock,
                IsHidden = response.Result.IsHidden
            };

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] UpdateProductDTO dto)
        {
            if (!ModelState.IsValid)
            {
                _notyfService.Error("Debe ajustar los errores de validación");
                return View(dto);
            }

            Response<ProductDTO> response = await _ProductsService.UpdateAsync(dto);

            if (!response.IsSuccess)
            {
                _notyfService.Error(response.Message);
                return View(dto);
            }

            _notyfService.Success(response.Message);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            Response<object> response = await _ProductsService.DeleteAsync(id);

            if (!response.IsSuccess)
            {
                _notyfService.Error(response.Message);
            }
            else
            {
                _notyfService.Success(response.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Toggle(ToggleProductStatusDTO dto)
        {
            Response<object> response = await _ProductsService.ToggleAsync(dto);

            if (!response.IsSuccess)
            {
                _notyfService.Error(response.Message);
            }
            else
            {
                _notyfService.Success(response.Message);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

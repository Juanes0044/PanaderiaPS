using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PanaderiaV2.Web.Core;
using PanaderiaV2.Web.Core.Pagination;
using PanaderiaV2.Web.Data;
using PanaderiaV2.Web.Data.Entities;
using PanaderiaV2.Web.DTOs.Product;
using PanaderiaV2.Web.Services.Abstractions;
using PanaderiaV2.Web.DTOs;


namespace PanaderiaV2.Web.Services.Implementations
{
    public class ProductService : CustomQueryableOperationsService, IProductsService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductService(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<CreateProductDTO>> CreateAsync(CreateProductDTO dto)
        {
            return await CreateAsync<CreateProductDTO, Product>(dto);
        }

        public async Task<Response<object>> DeleteAsync(Guid id)
        {
           return await DeleteAsync<Product>(id);
        }

        public async Task<Response<ProductDTO>> GetOneAsync(Guid id)
        {
            return await GetOneAsync<ProductDTO, Product>(id);
        }

        public async Task<Response<PaginationResponse<ProductDTO>>> GetPaginationAsync(PaginationRequest request)
        {
            IQueryable<Product> query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Filter))
            {
                // SELECT * FROM Products WHERE LOW(Name) LIKE '%LOW(FILTER)%'
                query = query.Where(s => s.Name.ToLower().Contains(request.Filter.ToLower())
                                      || s.Description.ToLower().Contains(request.Filter.ToLower()));
            }

            return await GetPagedListAsync<ProductDTO, Product>(request, query);
        }

        public async Task<Response<object>> ToggleAsync(ToggleProductStatusDTO dto)
        {
            try
            {
                Product? Product = await _context.Products.FirstOrDefaultAsync(s => s.Id == dto.ProductId);

                if (Product is null)
                {
                    return Response<object>.Failure($"No existe producto con id: {dto.ProductId}");
                }

                Product.IsHidden = dto.Hide;
                _context.Products.Update(Product);
                await _context.SaveChangesAsync();

                return Response<object>.Success("Producto actualizada con éxito");
            }

            catch(Exception ex)
            {
                return Response<object>.Failure(ex);
            }
        }

        public async Task<Response<ProductDTO>> UpdateAsync(UpdateProductDTO dto)
        {
            Response<UpdateProductDTO> result = await UpdateAsync<UpdateProductDTO, Product>(dto, dto.Id);
            ProductDTO dtoResponse = new ProductDTO
            {
                Id = result.Result.Id,
                Name = result.Result.Name,
                Description = result.Result.Description,
                stock = result.Result.stock,
                price = result.Result.price,
                IsHidden = result.Result.IsHidden
            };

            return  Response<ProductDTO>.Success(dtoResponse, result.Message);
        }
    }
}

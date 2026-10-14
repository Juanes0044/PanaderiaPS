
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Panaderia.web.Core;
using Panaderia.web.Core.Pagination;
using Panaderia.web.Data;
using Panaderia.web.Data.Entities;
using Panaderia.web.DTOs;
using Panaderia.web.Services.Abstractions;
using Panaderia.Web.Services;

namespace Panaderia.web.Services.Implementations
{
    public class ProductsService : CustomQueryableOperationService, IProductsService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductsService(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<CreateProductDTO>> CreateAsync(CreateProductDTO dto)
        {
            return await CreateAsync<CreateProductDTO, Product>(dto);
        }

        public Task<Response<object>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<object>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ProductDTO>>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<ProductDTO>> GetOneAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ProductDTO>> GetOneAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<PaginationResponse<ProductDTO>>> GetPaginationListAsync(PaginationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<object>> ToggleAsync(ToggleProductStatusDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ProductDTO>> UpdateAsync(UpdateProductDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
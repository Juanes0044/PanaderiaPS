using Panaderia.web.Core;
using Panaderia.web.Core.Pagination;
using Panaderia.web.Data.Entities;
using Panaderia.web.DTOs;

namespace Panaderia.web.Services.Abstractions
{
    public interface IProductsService
    {
        public Task<Response<CreateProductDTO>> CreateAsync(CreateProductDTO dto);
        
        public Task<Response<object>> DeleteAsync(Guid id);

        public Task<Response<ProductDTO>> GetOneAsync(Guid id);

        public Task<Response<ProductDTO>> UpdateAsync(UpdateProductDTO dto);
        public Task<Response<PaginationResponse<ProductDTO>>> GetPaginationListAsync(PaginationRequest request); 

        public Task<Response<List<ProductDTO>>> GetListAsync();


        public Task<Response<object>> ToggleAsync(ToggleProductStatusDTO dto);
    }
}

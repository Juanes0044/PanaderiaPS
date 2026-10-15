using PanaderiaV2.Web.Core;
using PanaderiaV2.Web.Core.Pagination;
using PanaderiaV2.Web.DTOs;
using PanaderiaV2.Web.DTOs.Product;


namespace PanaderiaV2.Web.Services.Abstractions

{
    public interface IProductsService
    {
        public Task<Response<CreateProductDTO>> CreateAsync(CreateProductDTO dto);
        public Task<Response<object>> DeleteAsync(Guid id);
        public Task<Response<ProductDTO>> GetOneAsync(Guid id);
        public Task<Response<PaginationResponse<ProductDTO>>> GetPaginationAsync(PaginationRequest request);
        public Task<Response<ProductDTO>> UpdateAsync(UpdateProductDTO dto);
        public Task<Response<object>> ToggleAsync(ToggleProductStatusDTO dto);
    }
}

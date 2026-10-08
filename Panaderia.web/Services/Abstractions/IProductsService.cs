using Panaderia.web.Data.Entities;
using Panaderia.web.DTOs;

namespace Panaderia.web.Services.Abstractions
{
    public interface IProductsService
    {
        Task<Product> CreateAsync(CreateProductDTO dto);
        Task DeleteAsync(int id);
        Task<List<Product>> GetListAsync();
        Task<UpdateProductDTO> GetOneAsync(int id);
        Task<Product> UpdateAsync(UpdateProductDTO dto);
    }
}
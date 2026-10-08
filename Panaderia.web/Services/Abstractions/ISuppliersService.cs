using Panaderia.web.Data.Entities;
using Panaderia.web.DTOs;


namespace Panaderia.wed.Services.Abstractios
{
    public interface ISuppliersService
    {
        Task<Supplier> CreateAsync(CreateSupplierDTO dto);
        Task DeleteAsync(int id);
        Task<List<Supplier>> GetListAsync();
        Task<UpdateSupplierDTO> GetOneAsync(int id);
        Task<Supplier> UpdateAsync(UpdateSupplierDTO dto);

    }
}
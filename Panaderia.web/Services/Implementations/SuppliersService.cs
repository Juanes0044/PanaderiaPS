using Microsoft.EntityFrameworkCore;
using Panaderia.web.Data;
using Panaderia.web.Data.Entities;
using Panaderia.web.DTOs;
using Panaderia.wed.Services.Abstractios;






namespace Panaderia.web.Services.Implementations
{
    public class SuppliersService: ISuppliersService
    {
        private readonly DataContext _context;

        public SuppliersService(DataContext context)
        {
            _context = context;
        }
        public async Task<Supplier> CreateAsync(CreateSupplierDTO dto)
        {
            Supplier supplier = new Supplier
            {
                Name = dto.Name,
                Phone = dto.Phone,
                Emial = dto.Email

            };

            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();

            return supplier;
        }

        public async Task DeleteAsync(int id)
        {
            Supplier? supplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == id);

            if (supplier is null)
            {
                throw new Exception("No existe proveedor con el id indicado");

            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

        }
        public async Task<List<Supplier>> GetListAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<UpdateSupplierDTO> GetOneAsync(int id)
        {
            Supplier? supplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == id);

            if (supplier is null)
            {
                throw new Exception("No existe proveedor con el id indicado");
            }

            return new UpdateSupplierDTO
            {
                Id = id,
                Name = supplier.Name,
                Phone = supplier.Phone,
                Email = supplier.Emial,
            };
        }

        public async Task<Supplier> UpdateAsync(UpdateSupplierDTO dto)
        {
            Supplier? supplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == dto.Id);

            if (supplier is null)
            {
                throw new Exception("No existe proveedor con el id indicado");
            }

            supplier.Name = dto.Name;
            supplier.Phone = dto.Phone;
            supplier.Emial = dto.Email;

            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();

            return supplier;
        }

        public Task<Supplier> UpdateAsync(UpdateProductDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}

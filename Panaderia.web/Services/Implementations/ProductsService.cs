using Panaderia.web.Data;
using Panaderia.web.Data.Entities;
using Panaderia.web.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Panaderia.web.DTOs;

namespace Panaderia.web.Services.Implementations
{
    public class ProductsService : IProductsService
    {
        private readonly DataContext _context;

        public ProductsService(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(CreateProductDTO dto)
        {
            Product product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                stock = dto.Stock,
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task DeleteAsync(int id)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
            {
                throw new Exception("No existe producto con el id indicado");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetListAsync()
        {
            List<Product> list = await _context.Products.ToListAsync();

            return list;
        }

        public async Task<UpdateProductDTO> GetOneAsync(int id)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
            {
                throw new Exception("No existe producto con el id indicado");
            }

            UpdateProductDTO dto = new UpdateProductDTO
            {
                Id = id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.stock,
            };

            return dto;
        }

        public async Task<Product> UpdateAsync(UpdateProductDTO dto)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.Id == dto.Id);

            if (product is null)
            {
                throw new Exception("No existe producto con el id indicado");
            }

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.stock = dto.Stock;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
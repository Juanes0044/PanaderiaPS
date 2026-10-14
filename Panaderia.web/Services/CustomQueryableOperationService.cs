using AutoMapper;
using Panaderia.web.Core;
using Panaderia.web.Data;
using Panaderia.web.Data.Abstractions;

namespace Panaderia.Web.Services
{
    public class CustomQueryableOperationService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CustomQueryableOperationService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<TDto>> CreateAsync<TDto,TEntity>(TDto dto) where TEntity : IId
        {
            try
            {
                TEntity entity = _mapper.Map<TEntity>(dto);

                Guid id = Guid.NewGuid();

                entity.Id = id;

                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                return Response<TDto>.Success(dto, "Registro creado con éxito");

            }
            catch(Exception ex)
            {
                return Response<TDto>.Failure(ex);
            }
        }
    }

}
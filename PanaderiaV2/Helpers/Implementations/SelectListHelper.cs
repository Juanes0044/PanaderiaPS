using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PanaderiaV2.Web.Data;
using PanaderiaV2.Web.Helpers.Abstractions;


namespace PanaderiaV2.Web.Helpers.Implementations
{
    public class SelectListHelper : ISelectListHelper
    {
        private readonly DataContext _context;

        public SelectListHelper(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SelectListItem>> GetSectionsSelectListAsync()
        {
            return await _context.Products.Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).ToListAsync();
        }
    }
}
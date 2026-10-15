using Microsoft.AspNetCore.Mvc.Rendering;

namespace PanaderiaV2.Web.Helpers.Abstractions
{
    public interface ISelectListHelper
    {
        Task<List<SelectListItem>> GetSectionsSelectListAsync();
    }
}
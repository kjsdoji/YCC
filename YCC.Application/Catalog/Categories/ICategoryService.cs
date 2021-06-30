using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCC.ViewModels.Catalog.Categories;

namespace YCC.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryVm>> GetAll(string languageId);

        Task<CategoryVm> GetById(string languageId, int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YCC.ViewModels.Catalog.Categories;
using YCC.ViewModels.Catalog.Products;
using YCC.ViewModels.Common;

namespace YCC.WebApp.Models
{
    public class ProductCategoryViewModel
    {
        public CategoryVm Category { get; set; }

        public PagedResult<ProductVm> Products { get; set; }
    }
}

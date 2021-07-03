using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YCC.ViewModels.Catalog.Categories;
using YCC.ViewModels.Catalog.ProductImages;
using YCC.ViewModels.Catalog.Products;

namespace YCC.WebApp.Models
{
    public class ProductDetailViewModel
    {
        public CategoryVm Category { get; set; }

        public ProductVm Product { get; set; }

        public List<ProductVm> RelatedProducts { get; set; }

        public List<ProductImageViewModel> ProductImages { get; set; }
    }
}

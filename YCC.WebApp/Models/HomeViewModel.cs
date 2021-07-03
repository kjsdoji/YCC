using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YCC.ViewModels.Catalog.Products;
using YCC.ViewModels.Utilities.Slides;

namespace YCC.WebApp.Models
{
    public class HomeViewModel
    {
        public List<SlideVm> Slides { get; set; }

        public List<ProductVm> FeaturedProducts { get; set; }

        public List<ProductVm> LatestProducts { get; set; }
    }
}

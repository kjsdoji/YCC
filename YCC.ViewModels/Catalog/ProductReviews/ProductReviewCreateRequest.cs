using System;
using System.Collections.Generic;
using System.Text;

namespace YCC.ViewModels.Catalog.ProductReviews
{
    public class ProductReviewCreateRequest
    {
        public string ProductId { set; get; }
        public string LanguageId { set; get; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}

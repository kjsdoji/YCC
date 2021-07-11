using System;
using System.Collections.Generic;
using System.Text;
using YCC.Data.Entities;

namespace YCC.ViewModels.Catalog.ProductReviews
{
    public class ProductReviewViewModel
    {
        public int Id { get; set; }
        //public string ProductName { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public int Rating { get; set; }
    }
}

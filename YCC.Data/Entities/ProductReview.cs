using System;
using System.Collections.Generic;
using System.Text;

namespace YCC.Data.Entities
{
    public class ProductReview
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public DateTime PublishedDate { get; set; }
        public int ProductId { get; set; }
        public Product Products { get; set; }
        public int Rating { get; set; }

    }
}

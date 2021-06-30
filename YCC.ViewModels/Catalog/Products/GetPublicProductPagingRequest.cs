using System;
using System.Collections.Generic;
using System.Text;
using YCC.ViewModels.Common;

namespace YCC.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using YCC.ViewModels.Common;

namespace YCC.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}

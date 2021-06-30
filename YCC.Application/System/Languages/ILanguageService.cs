using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCC.ViewModels.Common;
using YCC.ViewModels.System.Languages;
using YCC.ViewModels.System.Users;

namespace YCC.Application.System.Languages
{
    public interface ILanguageService
    {
        Task<ApiResult<List<LanguageVm>>> GetAll();
    }
}

using YCC.Application.System.Roles;
using YCC.Data.EF;
using YCC.Data.Entities;
using YCC.ViewModels.System.Roles;
using YCC.ViewModels.Utilities.Slides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YCC.Application.Utilities.Slides
{
    public class SlideService : ISlideService
    {
        private readonly YCCDbContext _context;

        public SlideService(YCCDbContext context)
        {
            _context = context;
        }

        public async Task<List<SlideVm>> GetAll()
        {
            var slides = await _context.Slides.OrderBy(x => x.SortOrder)
                .Select(x => new SlideVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Url = x.Url,
                    Image = x.Image
                }).ToListAsync();

            return slides;
        }
    }
}

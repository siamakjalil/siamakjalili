using Core.Context;
using Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Portfolio.Pages
{
    public class IndexModel(PortfolioDbContext portfolioDbContext, IMemoryCache memoryCache) : PageModel
    {
        public List<Experience> Experiences { get; set; } = [];
        public List<Skill> Skills { get; set; } = [];
        public async Task OnGet()
        {
            var experiences = memoryCache.Get<List<Experience>>("Experiences");
            var skills = memoryCache.Get<List<Skill>>("Skills");
            if (experiences != null && skills != null)
            {
                Experiences = experiences;
                Skills = skills;
                return;
            }
            Experiences = await portfolioDbContext.Experiences.OrderBy(x => x.Index).ToListAsync();
            Skills = await portfolioDbContext.Skills.OrderBy(x => x.Index).ToListAsync();
            var date = DateTime.Now.AddHours(24);
            memoryCache.Set("Experiences", Experiences, date);
            memoryCache.Set("Skills", Skills, date);
        }
    }
}

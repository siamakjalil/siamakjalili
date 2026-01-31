using Core.Context;
using Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Pages
{
    public class IndexModel(PortfolioDbContext portfolioDbContext) : PageModel
    {
        public List<Experience> Experiences { get; set; } = [];
        public List<Skill> Skills { get; set; } = [];
        public async Task OnGet()
        {
            Experiences = await portfolioDbContext.Experiences.OrderBy(x => x.Index).ToListAsync();
            Skills = await portfolioDbContext.Skills.OrderBy(x => x.Index).ToListAsync();
        }
    }
}

using Core.Context;
using Core.Models;
using FileUploader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Classes;

namespace Portfolio.Pages.Forms
{
    public class SkillsModel(PortfolioDbContext portfolioDbContext) : PageModel
    {
        public List<Skill> Skills { get; set; } = [];
        [BindProperty]
        public Skill? Skill { get; set; }
        [BindProperty]
        public IFormFile? ImgUp { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (!Access.Edit())
            {
                return NotFound();
            }
            if (id != null && id != 0)
            {
                Skill = await portfolioDbContext.Skills.FindAsync(id);
            }
            else
            {
                Skill = new Skill()
                {
                    Id = 0
                };
            }
            Skills = await portfolioDbContext.Skills.OrderBy(x => x.Index).ToListAsync();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!Access.Edit())
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (ImgUp != null)
            {
                if (!ImgUp.IsImage())
                {
                    return Page();
                }
                var imageInfo = ImgUp.GetImageInfo();
                if (imageInfo.Size > 3)
                {
                    return Page();
                }
            }
            if (Skill.Id == 0)
            {
                if (ImgUp == null)
                {
                    return Page();
                }
                Skill.Image = FileUploader.FileUploader.Upload(ImgUp, "", ImgPath.Images);
                await portfolioDbContext.AddAsync(Skill);
            }
            else
            {
                if (ImgUp != null)
                {
                    Skill.Image = FileUploader.FileUploader.Upload(ImgUp, "", ImgPath.Images);
                }
                portfolioDbContext.Update(Skill);
            }

            await portfolioDbContext.SaveChangesAsync();

            return Redirect("/Forms/Skills");
        }
    }
}

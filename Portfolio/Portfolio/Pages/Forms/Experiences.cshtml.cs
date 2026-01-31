using Core.Context;
using Core.Models;
using FileUploader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Classes;

namespace Portfolio.Pages.Forms
{
    public class ExperiencesModel(PortfolioDbContext portfolioDbContext) : PageModel
    {
        public List<Experience> Experiences { get; set; } = [];
        [BindProperty]
        public Experience? Experience { get; set; }
        [BindProperty]
        public IFormFile? ImgUp { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Experience = await portfolioDbContext.Experiences.FindAsync(id);
            }
            else
            {
                Experience = new Experience()
                {
                    Id = 0
                };
            }
            Experiences = await portfolioDbContext.Experiences.OrderBy(x => x.Index).ToListAsync();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
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
            if (Experience.Id == 0)
            {
                if (ImgUp == null)
                {
                    return Page();
                }
                Experience.Image = FileUploader.FileUploader.Upload(ImgUp, "", ImgPath.Images);
                await portfolioDbContext.AddAsync(Experience);
            }
            else
            {
                if (ImgUp != null)
                {
                    Experience.Image = FileUploader.FileUploader.Upload(ImgUp, "", ImgPath.Images);
                }
                portfolioDbContext.Update(Experience);
            }

            await portfolioDbContext.SaveChangesAsync();

            return Redirect("/Forms/Experiences");
        }
    }
}

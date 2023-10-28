using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Issues
{
    public class NewModel : PageModel
    {
        private readonly IssueDbContext _dbContext;
        public NewModel(IssueDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            Issue.Created = DateTime.Now;
            await _dbContext.Issues.AddAsync(Issue);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage("../Index");
        }

        [BindProperty]
        public Issue Issue { get; set; }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;


namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IssueDbContext _issueDbContext;
        public IndexModel(IssueDbContext issueDbContext, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _issueDbContext = issueDbContext;
        }

        public async void OnGet()
        {
            Issues = await _issueDbContext.Issues.Where(i => i.Completed == null)
                                                .OrderByDescending(i => i.Created)
                                                .ToListAsync();
        }
        public IEnumerable<Issue> Issues { set; get; } = Enumerable.Empty<Issue>();
    }
}
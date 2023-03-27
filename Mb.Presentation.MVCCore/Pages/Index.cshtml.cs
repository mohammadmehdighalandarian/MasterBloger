using Mb.infrastructure.Query;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using MB.Infrastructure.Query;

namespace Mb.Presentation.MVCCore.Pages
{
    public class IndexModel : PageModel
    {
        public List<ArticleQueryView> Articles { get; set; }
        
        private readonly IArticleQuery _articleQuery;

        public IndexModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public void OnGet()
        {
            Articles = _articleQuery.Get_All_Articles();
        }
    }
}
using Mb.infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mb.Presentation.MVCCore.Pages.Shared
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryView Article { get; set; }

        private readonly IArticleQuery _articleQuery;


        public ArticleDetailsModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public void OnGet(long id)
        {
            Article = _articleQuery.Get_ById(id);
        }
    }
}

using Mb.Application.contracts.Comment;
using Mb.infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mb.Presentation.MVCCore.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryView Article { get; set; }

        private readonly ICommentApplication _commentApplication;
        private readonly IArticleQuery _articleQuery;


        public ArticleDetailsModel(ICommentApplication commentApplication, IArticleQuery articleQuery)
        {
            _commentApplication = commentApplication;
            _articleQuery = articleQuery;
        }

        public void OnGet(long id)
        {
            Article = _articleQuery.Get_ById(id);
        }

        public RedirectToPageResult OnPost(CreateComment command)
        {
            _commentApplication.Create(command);
            return RedirectToPage("./ArticleDetails", new {id =command.ArticleId});
        }

    }
}
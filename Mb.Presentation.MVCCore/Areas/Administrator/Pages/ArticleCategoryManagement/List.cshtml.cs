using System.Collections.Generic;
using Mb.Application.contracts.ArticaleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public ListModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.Get_All_list();
        }

        public RedirectToPageResult OnPostRemove(long id)
        {
            _articleCategoryApplication.Delete(id);
            return RedirectToPage("./List");
        }

        public RedirectToPageResult OnPostActivate(long id)
        {
            _articleCategoryApplication.Activated(id);
            return RedirectToPage("./List");
        }
    }
}

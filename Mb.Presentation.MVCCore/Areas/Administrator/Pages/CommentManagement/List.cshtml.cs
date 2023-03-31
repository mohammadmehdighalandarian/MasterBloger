using System.Collections.Generic;
using Mb.Application.contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mb.Presentation.MVCCore.Areas.Administrator.Pages.CommentManagement
{
    public class ListModel : PageModel
    {
        public List<CommentViewModel> Comments { get; set; }

        private readonly ICommentApplication _commentApplication;

        public ListModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {
            Comments = _commentApplication.Get_All_Comment();
        }

        public RedirectToPageResult OnPostConfirm(long id)
        {
            _commentApplication.Change_To_Confiremed(id);
            return RedirectToPage("./List");
        }

        public RedirectToPageResult OnPostCancel(long id)
        {
            _commentApplication.Change_To_Cancel(id);
            return RedirectToPage("./List");
        }
    }
}
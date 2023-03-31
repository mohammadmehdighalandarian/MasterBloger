using Mb.Application.contracts.Comment;

namespace Mb.Application.contracts.Article
{
    public class ArticleViewModel
    {
        public long id { get; set; }

        public string Title { get; set; }

        public string ArticleCategory { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreationDate { get; set; }

        public List<CommentViewModel> Comments { get; set; }

    }
}

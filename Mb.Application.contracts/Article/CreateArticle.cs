namespace Mb.Application.contracts.Article
{
    public class CreateArticle
    {
        public string Title { get;  set; }

        public string ShortDiscreption { get;  set; }

        public string Image { get;  set; }

        public string Context { get;  set; }

        public long ArticleCategoryId { get; set; }
    }
}

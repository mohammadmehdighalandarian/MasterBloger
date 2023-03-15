using Mb.Domain.ArticleCategoryAgg.Services;

namespace Mb.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }

        public ArticleCategory(string title,IArticleCategoryValidatorServices validator)
        {
            validator.ArticleCategoryExist(title);
            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
        }

        public void Rename(string title,IArticleCategoryValidatorServices validator)
        {
            validator.ArticleCategoryExist(title);
            Title = title;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }
    }
}
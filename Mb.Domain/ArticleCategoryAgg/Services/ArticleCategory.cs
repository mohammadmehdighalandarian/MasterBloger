using System.Collections.ObjectModel;
using Mb.Domain.ArticleAgg;

namespace Mb.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public Collection<Article> articles { get; set; } = new Collection<Article>();


        public ArticleCategory(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception();
            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
        }

        public void IsExist(IArticleCategoryValidatorServices validator, string title)
        {
            validator.ArticleCategoryExist(title);
        }
        public void Rename(string title, IArticleCategoryValidatorServices validator)
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
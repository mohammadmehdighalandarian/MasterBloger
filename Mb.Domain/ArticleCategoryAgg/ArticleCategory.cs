using System.Collections.ObjectModel;
using _01_Framwork.Domain;
using Mb.Domain.ArticleAgg;
using Mb.Domain.ArticleCategoryAgg.Services;

namespace Mb.Domain.ArticleCategoryAgg
{
    public class ArticleCategory:DomainBase<long>
    {

        public string Title { get; private set; }

        public bool IsDeleted { get; private set; }

        public Collection<Article> articles { get; set; } = new Collection<Article>();


        public ArticleCategory(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception();
            Title = title;
            IsDeleted = false;
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
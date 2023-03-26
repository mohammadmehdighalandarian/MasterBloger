using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mb.Domain.ArticleAgg.Services;
using Mb.Domain.ArticleCategoryAgg.Services;

namespace Mb.Domain.ArticleAgg
{
    public class Article
    {
        public long id { get; }

        public string Title { get; private set; }

        public string ShortDiscreption { get; private set; }

        public string Image { get; private set; }

        public string Context { get; private set; }

        public bool IsDeleted { get; private set; }

        public DateTime CreationDate { get; private set; }

        public long ArticleCategoryId { get; private set; }

        public ArticleCategory ArticleCategory { get;  set; }


        public Article(string title, string shortDiscreption, string image, string context, long articleCategoryId)
        {
            Validate(title, articleCategoryId);

            Title = title;
            ShortDiscreption = shortDiscreption;
            Image = image;
            Context = context;
            ArticleCategoryId= articleCategoryId;
            CreationDate =DateTime.Now;
            IsDeleted=false;
        }

        public void IsExist(IArticleValidatorServices validator, string title)
        {
            validator.ArticleExist(title);
        }
        private static void Validate(string title, long articleCategoryId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("Fill the Title");
            if (articleCategoryId == 0)
                throw new ArgumentOutOfRangeException();
        }

        public void Edit(string title, string shortDiscreption, string image, string context, long articleCategoryId)
        {
            Validate(title, articleCategoryId);
            Title = title;
            ShortDiscreption = shortDiscreption;
            Image = image;
            Context = context;
            ArticleCategoryId = articleCategoryId;
        }

        public void Remove()
        {
            IsDeleted=true;
        }

        public void Restore()
        {
            IsDeleted = false;
        }
    }
}

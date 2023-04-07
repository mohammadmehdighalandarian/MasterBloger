using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framwork.Domain;
using Mb.Domain.ArticleAgg.Services;
using Mb.Domain.ArticleCategoryAgg;
using Mb.Domain.CommentAgg;

namespace Mb.Domain.ArticleAgg
{
    public class Article:DomainBase<long>
    {

        public string Title { get; private set; }

        public string ShortDiscreption { get; private set; }

        public string Image { get; private set; }

        public string Context { get; private set; }

        public bool IsDeleted { get; private set; }


        public long ArticleCategoryId { get; private set; }

        public ArticleCategory ArticleCategory { get;  set; }

        public ICollection<Comment> Comments { get; private set; }=new List<Comment>();


        public Article(string title, string shortDiscreption, string image, string context, long articleCategoryId)
        {
            Validate(title, articleCategoryId);

            Title = title;
            ShortDiscreption = shortDiscreption;
            Image = image;
            Context = context;
            ArticleCategoryId= articleCategoryId;
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

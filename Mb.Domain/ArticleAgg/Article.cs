using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Title = title;
            ShortDiscreption = shortDiscreption;
            Image = image;
            Context = context;
            ArticleCategoryId= articleCategoryId;
            CreationDate =DateTime.Now;
            IsDeleted=false;
        }

        public void Edit(string title, string shortDiscreption, string image, string context, long articleCategoryId)
        {
            Title = title;
            ShortDiscreption = shortDiscreption;
            Image = image;
            Context = context;
            ArticleCategoryId = articleCategoryId;
        }
    }
}

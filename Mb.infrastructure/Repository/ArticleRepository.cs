﻿using Mb.Domain.ArticleAgg;
using Mb.Domain.ArticleAgg.Repository;
using Mb.Domain.ArticleCategoryAgg;
using Mb.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace Mb.infrastructure.EFCore.Repository
{
    public class ArticleRepository:IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<Article> Get_all_Articles()
        {
            return _context.Articles
                .Include(x => x.Comments)
                .ToList();
        }

      
        public void Create(Article article)
        {
            _context.Articles.Add(article);
            Save();
        }

        public Article Get_BY_Id(long id)
        {
            return _context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public ArticleCategory Get(long id)
        {
            return _context.ArticleCategories.FirstOrDefault(x => x.Id == id);
        }

        public bool Exist(string titel)
        {
            return _context.Articles.Any(x => x.Title == titel);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

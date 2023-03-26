using Mb.Domain.ArticleAgg;
using Mb.Domain.ArticleCategoryAgg.Services;
using Mb.infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Mb.infrastructure
{
    public class MasterBloggerContext:DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }

        public MasterBloggerContext(DbContextOptions<MasterBloggerContext>options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            modelBuilder.ApplyConfiguration(new ArticleMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
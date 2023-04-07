using Mb.Domain.ArticleAgg;
using Mb.Domain.ArticleCategoryAgg;
using Mb.Domain.CommentAgg;
using Mb.infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Mb.infrastructure
{
    public class MasterBloggerContext:DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public MasterBloggerContext(DbContextOptions<MasterBloggerContext>options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly=typeof(ArticleMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            //modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            //modelBuilder.ApplyConfiguration(new ArticleMapping());
            //modelBuilder.ApplyConfiguration(new CommentMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
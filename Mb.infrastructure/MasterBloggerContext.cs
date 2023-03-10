using Mb.Domain;
using Mb.infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Mb.infrastructure
{
    public class MasterBloggerContext:DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public MasterBloggerContext(DbContextOptions<MasterBloggerContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
using Mb.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mb.infrastructure.EFCore.Mapping
{
    public class ArticleCategoryMapping:IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategory");
            builder.HasKey(x => x.Id);

            #region Relation

            builder.HasMany(x => x.articles)
                .WithOne(x => x.ArticleCategory)
                .HasForeignKey(x => x.ArticleCategoryId);

            #endregion
        }
    }
}

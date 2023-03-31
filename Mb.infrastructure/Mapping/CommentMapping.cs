using Mb.Domain.ArticleCategoryAgg.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mb.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mb.infrastructure.EFCore.Mapping
{
    public class CommentMapping: IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.HasKey(x => x.Id);


            #region Relation

            builder.HasOne(x => x.Article)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.ArticleId);

            #endregion
        }
    }
}

using ASP_Projekat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.DataAccess.Configurations
{
    public class BlogConfiguration : EntityConfig<Blog>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.BlogContent).IsRequired().HasMaxLength(1024);
            builder.HasIndex(x => x.BlogContent);
            builder.HasMany(x => x.BlogTags).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Comments).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.BlogImages).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.BlogReactions).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}

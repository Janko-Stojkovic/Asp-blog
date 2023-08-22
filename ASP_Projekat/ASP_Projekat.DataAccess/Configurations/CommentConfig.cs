using ASP_Projekat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.DataAccess.Configurations
{
    public class CommentConfig : EntityConfig<Comment>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.CommentContent).IsRequired().HasMaxLength(1000);
            builder.HasIndex(x => x.CommentContent);
            builder.HasMany(x => x.Children).WithOne(x => x.ParentCommment).HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

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
    public class TagConfig : EntityConfig<Tag>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(x => x.TagText).IsRequired().HasMaxLength(40);
            builder.HasIndex(x => x.TagText).IsUnique();
            builder.HasMany(x => x.BlogTags).WithOne(x => x.Tag).HasForeignKey(x => x.TagId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

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
    public class UserConfig : EntityConfig<User>
    {
        protected override void ConfigureRules(EntityTypeBuilder<User> builder)
        {
            builder.Property(x=>x.FirstName).IsRequired().HasMaxLength(25);
            builder.Property(x=>x.LastName).IsRequired().HasMaxLength(25);
            builder.Property(x=>x.Username).IsRequired().HasMaxLength(35);
            builder.Property(x=>x.Email).IsRequired().HasMaxLength(60);
            builder.Property(x=>x.Password).IsRequired().HasMaxLength(120);
            builder.HasIndex(x => x.Username).IsUnique(); 
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasMany(x => x.Comments).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=>x.Blogs).WithOne(x => x.User).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.BlogReactions).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}

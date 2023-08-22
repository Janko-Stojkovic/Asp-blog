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
    public class ImageConfig : EntityConfig<Image>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(256);
            builder.Property(x => x.ImageSize).IsRequired();
            builder.HasIndex(x => x.ImageUrl);
            builder.HasMany(x => x.Users).WithOne(x => x.Image).HasForeignKey(x => x.ProfileImageId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.BlogImages).WithOne(x => x.Image).HasForeignKey(x => x.ImageId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

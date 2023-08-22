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
    public class RoleConfig : EntityConfig<Role>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x=>x.RoleName).IsRequired().HasMaxLength(64);  
            builder.HasIndex(x=>x.RoleName).IsUnique();
            builder.HasMany(x => x.Users).WithOne(x => x.Role).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

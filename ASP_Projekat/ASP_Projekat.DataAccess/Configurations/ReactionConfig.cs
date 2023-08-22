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
    public class ReactionConfig : EntityConfig<Reaction>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Reaction> builder)
        {
            builder.Property(x=>x.ReactionName).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.ReactionName).IsUnique();
            builder.HasMany(x => x.Reactions).WithOne(x => x.Reaction).HasForeignKey(x => x.ReactionId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}

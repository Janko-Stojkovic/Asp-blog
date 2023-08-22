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
    public abstract class EntityConfig<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x=>x.UpdatedBy).HasMaxLength(100);
            builder.Property(x=>x.DeletedBy).HasMaxLength(100);
            ConfigureRules(builder);
        }

        protected abstract void ConfigureRules(EntityTypeBuilder<T> builder);
    }
}

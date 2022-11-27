using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Models
{
   public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID).IsRequired();
            builder.Property(p => p.NameAR).IsRequired().HasMaxLength(500);
            builder.Property(p => p.NameEN).IsRequired().HasMaxLength(500);
            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);

        }
    }
}

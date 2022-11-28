using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Models
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Property(i => i.UserName)
                .IsRequired().HasMaxLength(500);
            builder.Property(i => i.Address)
                .IsRequired().HasMaxLength(1000);
            builder.Property(i => i.MobileNumber)
                .IsRequired().HasMaxLength(200);
            builder.Property(i => i.DateEntered)
                .IsRequired();
           
            builder.Property(i => i.IsDeleted).IsRequired().HasDefaultValue(false); ;




        }
    }
}

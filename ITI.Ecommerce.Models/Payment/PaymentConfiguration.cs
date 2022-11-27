using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Models
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment");
            builder.HasKey(i => i.ID);
            builder.Property(i => i.ID)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Property(i => i.PaymentType)
                .IsRequired().HasMaxLength(100);
            builder.Property(i => i.IsAllowed)
                .IsRequired();
        }
    }
}

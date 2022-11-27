using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Models
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(i => i.ID);
            builder.Property(i => i.ID).ValueGeneratedOnAdd();
            builder.Property(i => i.CustomerId).IsRequired();
            builder.Property(i => i.PaymentId).IsRequired();
            builder.Property(i => i.OrderDate).IsRequired();
            builder.Property(i => i.IsDeleted).IsRequired().HasDefaultValue(false); ;
            builder.Property(i => i.ShoppingCartId).IsRequired();
        }
    }
}

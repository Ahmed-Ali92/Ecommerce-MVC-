using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Models
{
    public static class RelationshipsMapping
    {
        public static void MapRelationships(this ModelBuilder builder)
        {

            //Relation one to many between Category and Product
            builder
               .Entity<Product>()
               .HasOne(i => i.Category)
               .WithMany(i => i.ProductList)
               .HasForeignKey(i => i.CategoryID)
               .IsRequired().OnDelete(DeleteBehavior.Cascade);

            //Relation one to many between Category and ProductImage
            builder
               .Entity<ProductImage>()
               .HasOne(i => i.Product)
               .WithMany(i => i.productImageList)
               .HasForeignKey(i => i.ProductID)
               .IsRequired().OnDelete(DeleteBehavior.Cascade);

            //Relation Many to many between Shopping Cart and Product
            builder
               .Entity<ShoppingCart>()
               .HasMany(i => i.productList)
               .WithMany(i => i.ShoppingCartList);

            //Relation One to One between Shopping Cart and Order
            builder
               .Entity<ShoppingCart>()
              .HasOne(i => i.Order).WithOne(i => i.ShoppingCart);

            //Relation Many to many between Customer and Order
            builder
               .Entity<Customer>()
               .HasMany(i => i.orderList)
               .WithMany(i => i.customersList);

            //Relation One to One between Payment and Order
            builder
               .Entity<Payment>()
              .HasOne(i => i.Order).WithOne(i => i.Payment);
        }
    }
}

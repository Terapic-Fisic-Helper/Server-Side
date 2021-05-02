using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerapicFisicHelper.Entities;

namespace TerapicFisicHelper.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user").HasKey(u => u.Id);
            builder.Property(u => u.Id);
            builder.Property(u => u.Name).HasColumnName("name").HasMaxLength(50);
            builder.Property(u => u.LastName).HasColumnName("lastname").HasMaxLength(50);
            builder.Property(u => u.Description).HasColumnName("description").HasMaxLength(255);
            builder.Property(u => u.Birth);
            builder.Property(u => u.Address).HasColumnName("address").HasMaxLength(255);
            builder.Property(u => u.Phone);
            builder.Property(u => u.Age);
            builder.Property(u => u.Email).HasColumnName("email").HasMaxLength(100);
            builder.Property(u => u.Country).HasColumnName("country").HasMaxLength(80);
            builder.Property(u => u.Gender).HasColumnName("gender").HasMaxLength(20);
            builder.Property(u => u.Password).HasMaxLength(8);

            builder.HasOne(c => c.Customer)
                .WithOne(c => c.User)
                .HasForeignKey<Customer>(c => c.UserId)
                .HasConstraintName("fk_user_customer")
                .IsRequired(true);

            builder.HasOne(c => c.Specialist)
                .WithOne(c => c.User)
                .HasForeignKey<Specialist>(c => c.UserId)
                .HasConstraintName("fk_user_specialist")
                .IsRequired(true);

        }
    }
}

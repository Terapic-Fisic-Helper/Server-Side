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
    public class SubscriptionMap : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("subscriptions");
            builder.HasKey(h => h.StartDate);
            builder.HasKey(h => h.CustomerId);
            builder.HasKey(h => h.SubscriptionPlanId);
            builder.Property(c => c.CustomerId).HasColumnName("customer_id");
            builder.Property(s => s.SubscriptionPlanId).HasColumnName("subscriptionplan_id");

            builder.Property(s => s.StartDate).IsRequired();
            builder.Property(s => s.ExpiryDate).IsRequired();

            builder.HasOne(s => s.Customer)
                .WithMany(c => c.Subscriptions)
                .HasForeignKey(s => s.CustomerId)
                .HasConstraintName("fk_suscription_customer")
                .IsRequired(true);

            builder.HasOne(s => s.SubscriptionPlan)
                .WithMany(sp => sp.Subscriptions)
                .HasForeignKey(s => s.SubscriptionPlanId)
                .HasConstraintName("fk_suscription_plan")
                .IsRequired(true);
        }
    }
}

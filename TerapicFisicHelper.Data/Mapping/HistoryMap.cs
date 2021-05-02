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
    public class HistoryMap : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.ToTable("histories");
            builder.HasKey(h => h.CustomerId);
            builder.HasKey(h => h.SessionId);
            builder.Property(h => h.CustomerId).HasColumnName("customer_id");
            builder.Property(h => h.SessionId).HasColumnName("session_id");
            builder.Property(h => h.Watched).IsRequired();

            builder.HasOne(h => h.Customer)
                .WithMany(c => c.Histories)
                .HasForeignKey(h => h.CustomerId)
                .HasConstraintName("fk_history_customer")
                .IsRequired(true);

            builder.HasOne(h => h.Session)
                .WithMany(s => s.Histories)
                .HasForeignKey(h => h.SessionId)
                .HasConstraintName("fk_history_session")
                .IsRequired(true);
        }
    }
}

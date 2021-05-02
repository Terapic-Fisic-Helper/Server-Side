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
    public class EquipamentSessionMap : IEntityTypeConfiguration<EquipamentSession>
    {
        public void Configure(EntityTypeBuilder<EquipamentSession> builder)
        {
            builder.ToTable("equipament_sessions");
            builder.HasKey(h => h.EquipamentId);
            builder.HasKey(h => h.SessionId);
            builder.Property(h => h.EquipamentId).HasColumnName("equipament_id");
            builder.Property(h => h.SessionId).HasColumnName("session_id");

            builder.HasOne(es => es.Equipament).
                WithMany(e => e.EquipamentSessions).
                HasForeignKey(es => es.EquipamentId)
                .HasConstraintName("fk_Equipament_Equipamentsession")
                .IsRequired(true);

            builder.HasOne(es => es.Session)
                .WithMany(s => s.EquipamentSessions)
                .HasForeignKey(es => es.SessionId)
                .HasConstraintName("fk_Ession_Equipamentsession")
                .IsRequired(true);
        }
    }
}

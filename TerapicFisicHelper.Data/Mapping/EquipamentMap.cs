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
    public class EquipamentMap : IEntityTypeConfiguration<Equipament>
    {
        public void Configure(EntityTypeBuilder<Equipament> builder)
        {
            builder.ToTable("equipaments");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("equipaments_id");
            builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(50);
            builder.Property(e => e.Description).HasColumnName("description").HasMaxLength(255);
        }
    }
}

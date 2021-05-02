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
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("tags");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("tag_id");
            builder.Property(t => t.Name).HasColumnName("name").HasMaxLength(50);
            builder.Property(t => t.Description).HasColumnName("description").HasMaxLength(255);
        }
    }
}

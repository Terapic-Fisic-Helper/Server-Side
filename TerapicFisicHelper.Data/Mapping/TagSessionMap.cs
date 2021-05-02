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
    public class TagSessionMap : IEntityTypeConfiguration<TagSession>
    {
        public void Configure(EntityTypeBuilder<TagSession> builder)
        {
            builder.ToTable("tag_sessions");
            builder.HasKey(h => h.TagId);
            builder.HasKey(h => h.SessionId);
            builder.Property(r => r.TagId).HasColumnName("tag_id");
            builder.Property(r => r.SessionId).HasColumnName("session_id");

            builder.HasOne(ts => ts.Tag)
                .WithMany(ts => ts.TagSessions)
                .HasForeignKey(ts => ts.TagId)
                .HasConstraintName("fk_TagSession_tag")
                .IsRequired(true);
            
            builder.HasOne(ts => ts.Session)
                .WithMany(s => s.TagSessions)
                .HasForeignKey(ts => ts.SessionId)
                .HasConstraintName("fk_TagSession_session")
                .IsRequired(true);
        }
    }
}

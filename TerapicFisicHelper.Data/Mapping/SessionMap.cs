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
    public class SessionMap : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("sessions");
            builder.HasKey(ss => ss.Id);
            builder.Property(ss => ss.Id).HasColumnName("sessions_id");
            builder.Property(ss => ss.Title).HasColumnName("title").HasMaxLength(50);
            builder.Property(ss => ss.Description).HasColumnName("description").HasMaxLength(255);
            builder.Property(ss => ss.StartDate);
            builder.Property(ss => ss.StartHour).HasMaxLength(5);
            builder.Property(ss => ss.EndHour).HasMaxLength(5);
        }
    }
}

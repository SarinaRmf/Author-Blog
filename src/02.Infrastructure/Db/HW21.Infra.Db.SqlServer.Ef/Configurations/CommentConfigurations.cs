using HW21.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Infra.Db.SqlServer.Ef.Configurations
{
    public class CommentConfigurations : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Property(c => c.FirstName).HasMaxLength(50);
            builder.Property(c => c.LastName).HasMaxLength(70);
            builder.Property(c => c.Email).HasMaxLength(80);    

        }
    }
}

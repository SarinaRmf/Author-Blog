using HW21.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Infra.Db.SqlServer.Ef.Configurations
{
    public class PostConfigurations : IEntityTypeConfiguration<Post>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Post> builder)
        {
            builder.HasOne(p => p.Author)
                .WithMany(a => a.Posts)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Post)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Title).HasMaxLength(255);
            builder.Property(p => p.Description).HasMaxLength(1000);

        }
    }
}

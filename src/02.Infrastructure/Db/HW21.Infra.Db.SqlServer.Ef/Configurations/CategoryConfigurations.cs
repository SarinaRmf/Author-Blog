using HW21.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Infra.Db.SqlServer.Ef.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(c => c.Post)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(c => c.Author)
                .WithMany(a => a.Categories)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict); 


        }
    }
}

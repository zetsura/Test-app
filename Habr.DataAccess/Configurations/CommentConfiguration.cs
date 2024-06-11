﻿using Habr.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Habr.DataAccess.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> entityTypeBuilder)
        {
            entityTypeBuilder
                .Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            entityTypeBuilder
                .Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(300);

            entityTypeBuilder
                .Property(c => c.Created)
                .IsRequired()
                .HasColumnType("datetime");

            entityTypeBuilder
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            entityTypeBuilder
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comentario");   //EF asume que el nombre de la tabla es como se encuentra en la linea 19

            builder.HasKey(e => e.CommentId);

            builder.Property(e => e.CommentId)
                .HasColumnName("IdComentario")
                .ValueGeneratedNever();

            builder.Property(e => e.PostId)
                .HasColumnName("IdPublicacion")
                .ValueGeneratedNever();

            builder.Property(e => e.UserId)
                .HasColumnName("IdUsuario")
                .ValueGeneratedNever();

            builder.Property(e => e.Description)
                .HasColumnName("Descripcion")
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Date)
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

            builder.Property(e => e.IsActive)
                .HasColumnName("Activo")
                .ValueGeneratedNever();

            builder.HasOne(d => d.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Publicacion");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Usuario");
        }
    }
}

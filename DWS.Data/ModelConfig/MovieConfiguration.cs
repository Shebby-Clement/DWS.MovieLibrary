using DWS.MovieLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.MovieLibrary.Data.ModelConfig
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> entity)
        {
            entity.ToTable("Movie");
            entity.HasKey(e => e.ID);
            entity.Property(p => p.Country).IsRequired();
            entity.Property(p => p.Name).IsRequired();
            entity.Property(p => p.CreatedAt).IsRequired();
            entity.Property(p => p.ModifiedAt).IsRequired();
            entity.Property(p => p.Genre).IsRequired();

            entity.Property(p => p.Rating).IsRequired();
            entity.Property(p => p.Year).IsRequired();
            entity.Property(p => p.Language).IsRequired();
            // etc.
        }
    }
}

using DWS.MovieLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.MovieLibrary.Data.ModelConfig
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> entity)
        {
            entity.ToTable("Person");
            entity.HasKey(e => e.ID);
            entity.Property(p => p.FirstName).IsRequired();
            entity.Property(p => p.LastName).IsRequired();
            entity.Property(p => p.CreatedAt).IsRequired();
            entity.Property(p => p.ModifiedAt).IsRequired();
            entity.Property(p => p.Gender).IsRequired();

            entity.Property(p => p.Role).IsRequired();
            // etc.
        }
    }
}

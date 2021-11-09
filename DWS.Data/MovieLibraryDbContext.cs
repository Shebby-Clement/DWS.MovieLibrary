using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DWS.MovieLibrary.Data.ModelConfig;
using DWS.MovieLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.MovieLibrary.Data
{

    public class MovieLibraryDbContext : DbContext
    {
        #region Properties
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Person> Person { get; set; }

        #endregion

        public MovieLibraryDbContext(DbContextOptions<MovieLibraryDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new PersonConfiguration());
            base.OnModelCreating(builder);
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}

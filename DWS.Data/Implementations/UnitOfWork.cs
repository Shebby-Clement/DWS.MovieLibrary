using DWS.MovieLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.MovieLibrary.Data.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private MovieLibraryDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public MovieLibraryDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}

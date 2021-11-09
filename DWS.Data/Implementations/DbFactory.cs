using DWS.MovieLibrary.Core;
using DWS.MovieLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.MovieLibrary.Data.Implementations
{
    public class DbFactory : Disposable, IDbFactory
    {
        MovieLibraryDbContext _dbContext;

        public DbFactory(MovieLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MovieLibraryDbContext Init()
        {

            if (_dbContext == null)
            {
                throw new Exception($"Please initialize your DbContext");
            }
            return _dbContext;
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}

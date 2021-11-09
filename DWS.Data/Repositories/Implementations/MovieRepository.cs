using DWS.MovieLibrary.Data.Interfaces;
using DWS.MovieLibrary.Data.Repositories.Interfaces;
using DWS.MovieLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.MovieLibrary.Data.Repositories.Implementations
{
    public class MovieRepository: BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}

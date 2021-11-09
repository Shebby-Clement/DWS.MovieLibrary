using DWS.MovieLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.MovieLibrary.Services.Interfaces
{
    public interface IMovieService
    {
        #region GENERAL CRUD
        Movie GetMovieByID(string MovieId);
        void UpdateMovie(Movie Movie);
        void CreateMovie(Movie Movie);
        void DeleteMovie(string MovieId);
        #endregion

        IEnumerable<Movie> GetAll();
        IEnumerable<Movie> SaerchMovie(string query, bool withActors = false);
        void Save();
    }
}

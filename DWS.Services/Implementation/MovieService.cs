using DWS.MovieLibrary.Data.Interfaces;
using DWS.MovieLibrary.Data.Repositories.Interfaces;
using DWS.MovieLibrary.Domain.Models;
using DWS.MovieLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DWS.MovieLibrary.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMovieRepository MovieRepository;

        public MovieService(IUnitOfWork unitOfWork, IMovieRepository MovieRepository)
        {
            this.unitOfWork = unitOfWork;
            this.MovieRepository = MovieRepository;
        }

        public void CreateMovie(Movie Movie)
        {
            MovieRepository.Add(Movie);
        }

        public Movie GetMovieByID(string MovieId)
        {
            return MovieRepository.GetById(MovieId);
        }

        public void UpdateMovie(Movie Movie)
        {
            MovieRepository.Update(Movie);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void DeleteMovie(string MovieId)
        {
            MovieRepository.Delete(MovieId);
        }

        public IEnumerable<Movie> GetAll()
        {
            return MovieRepository.GetAll();
        }


        public IEnumerable<Movie> SaerchMovie(string query, bool withActors = false)
        {
            return new List<Movie>();
        }
    }
}

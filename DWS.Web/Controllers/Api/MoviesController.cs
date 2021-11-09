using AutoMapper;
using DWS.MovieLibrary.Domain.Dtos;
using DWS.MovieLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using DWS.MovieLibrary.Domain.Models;
using System.Net;

namespace DWS.MovieLibrary.Web.Controllers.Api
{
    //[Authorize]
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : BaseController
    {
        #region Fields

        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public MoviesController(IMapper mapper, IMovieService movieService) : base()
        {
            _mapper = mapper;
            _movieService = movieService;
        }

        #endregion

        #region MOVIE OPERTAIONS api

        [Route("all")]
        [HttpGet]
        [ResponseType(typeof(List<MovieDto>))]
        public async Task<IActionResult> GetAll()
        {

            var data = _movieService.GetAll();
            var dataDto = _mapper.Map<List<MovieDto>>(data);

            if (dataDto != null)
            {
                return Ok(dataDto);
            }

            return NotFound();
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(MovieDto))]
        public async Task<IActionResult> PostMovie(MovieDto MovieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var Movie = _mapper.Map<Movie>(MovieDTO);

                _movieService.CreateMovie(Movie);

                _movieService.Save();

                return Ok(MovieDTO);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [Route("getbyid/{MovieId}")]
        [HttpGet]
        [ResponseType(typeof(MovieDto))]
        public async Task<IActionResult> GetMovie(string MovieId)
        {
            var Movie = _movieService.GetMovieByID(MovieId);

            if (Movie == null)
            {
                return NotFound();
            }

            var dataDto = _mapper.Map<MovieDto>(Movie);

            return Ok(dataDto);
        }

        [Route("MoviesByFilter/{name}")]
        [HttpGet]
        [ResponseType(typeof(List<MovieDto>))]
        public async Task<IActionResult> GetMoviesByFilter(string name)
        {
            IEnumerable<Movie> Movies = _movieService.GetAll();

            if (Movies == null)
            {
                return NotFound();
            }


            if (!string.IsNullOrEmpty(name))
            {
                Movies = Movies.Where(t => t.Name.ToLower().Contains(name.ToLower())).ToList();
            }

            if (Movies == null)
            {
                return NotFound();
            }

            return Ok(Movies);

        }

        [Route("delete/{MovieId}")]
        [HttpDelete]
        [ResponseType(typeof(MovieDto))]
        public async Task<IActionResult> DeleteMovie(string MovieId)
        {

            try
            {
                var movieList = _movieService.GetAll();

                var movie = movieList.Where(m => m.ID == MovieId).SingleOrDefault();

                if (movie == null)
                {
                    return NotFound();
                }

                _movieService.DeleteMovie(MovieId);

                _movieService.Save();

                return Ok($"Movie with ID: {MovieId} has deleted");
            }
            catch (Exception error)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, error.Message);
            }
        }

        [Route("update/{MovieId}")]
        [ResponseType(typeof(MovieDto))]
        [HttpPut]
        public async Task<IActionResult> PutMovie(Guid MovieId, MovieDto MovieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (MovieId != MovieDTO.ID)
            {
                return BadRequest();
            }


            try
            {
                var Movie = _mapper.Map<Movie>(MovieDTO);

                _movieService.UpdateMovie(Movie);

                _movieService.Save();

                var dataDTO = _mapper.Map<MovieDto>(MovieDTO);

                return Ok(dataDTO);
            }
            catch (Exception error)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Error : {error.Message}");
            }
        }

        #endregion
    }
}

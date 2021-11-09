using DWS.MovieLibrary.Core.Extensions;
using DWS.MovieLibrary.Domain.Dtos;
using DWS.MovieLibrary.Web.Controllers.HttpClient;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DWS.MovieLibrary.Web.Controllers
{

    public class MoviesController : CoreController
    {
        private readonly IApiClient _apiClient;
        public MoviesController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {

            var result = await _apiClient.Get<List<MovieDto>>(GetBaseuRL(), "/api/movies/all");

            if (!result.HasError)
            {
                return View(result.Result);
            }
            else
            {
                return View("Error");

            }

        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }


        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieDto movie)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    var postTask = await _apiClient.Create(GetBaseuRL(), "/api/movies/add", movie);

                    if (postTask.HasError)
                    {
                        if (postTask.Error.StatusCode == (int)HttpStatusCode.NotFound)
                        {
                            ModelState.AddModelError(string.Empty, $"");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, $"{postTask.Error.ReasonPhrase}");

                        }

                        return RedirectToAction("Create");
                    }
                }
                catch (Exception er)
                {
                    er.LogError();
                }

                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }


        //GET - EDIT
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var result = await _apiClient.Get<MovieDto>(GetBaseuRL(), $"/api/Movies/getbyid/{id}");

            if (!result.HasError)
            {
                return View(result.Result);
            }
            else
            {
                return NotFound();
            }
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieDto movie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postTask = await _apiClient.Update(GetBaseuRL(), $"/api/Movies/update/{movie.ID}", movie);

                    if (postTask.HasError)
                    {
                        if (postTask.Error.StatusCode == (int)HttpStatusCode.NotFound)
                        {
                            ModelState.AddModelError(string.Empty, $"");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, $"{postTask.Error.ReasonPhrase}");

                        }
                        return View(movie);
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception er)
                {
                    er.LogError();
                }
            }
            return View(movie);

        }

        //GET - DELETE
        public async Task<IActionResult> DeleteRecord(string id, object data = null)
        {
            if (id == null || string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var result = await _apiClient.Get<MovieDto>(GetBaseuRL(), $"/api/Movies/getbyid/{id}");

            if (!result.HasError)
            {
                return View(result.Result);
            }
            else
            {
                return NotFound();
            }
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRecord(string id)
        {
            if (id == null || string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var result = await _apiClient.Delete<MovieDto>(GetBaseuRL(), $"/api/Movies/delete", id);

            if (!result.HasError)
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }

    }
}

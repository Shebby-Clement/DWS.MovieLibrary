
using DWS.MovieLibrary.Core.Extensions;
using DWS.MovieLibrary.Domain.Dtos;
using DWS.MovieLibrary.Web.Controllers;
using DWS.MovieLibrary.Web.Controllers.HttpClient;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DWS.PersonLibrary.Web.Controllers
{

    public class PersonsController : CoreController
    {
        private readonly IApiClient _apiClient;
        public PersonsController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index( string id = null)
        {

            var result = await _apiClient.Get<List<PersonDto>>(GetBaseuRL(), "/api/Persons/all");

            if (!result.HasError)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    return View(result.Result.Where( m => m.MovieID == id));
                }
                return View(result.Result);
            }
            else
            {
                return View("Error");

            }

        }

        //GET - CREATE
        public async  Task<IActionResult> Create()
        {
            var Person = new PersonDto();

            var result = await _apiClient.Get<List<MovieDto>>(GetBaseuRL(), "/api/movies/all");

            if (!result.HasError)
            {
                Person.MovieList = result.Result.Select(m => new MovieLibrary.Domain.Models.DropDownItem { Text = m.Name, Value = m.ID }).ToList();
            }
            return View(Person);
        }


        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonDto Person)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    var postTask = await _apiClient.Create(GetBaseuRL(), "/api/Persons/add", Person);

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

            var result = await _apiClient.Get<PersonDto>(GetBaseuRL(), $"/api/Persons/getbyid/{id}");

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
        public async Task<IActionResult> Edit(PersonDto Person)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postTask = await _apiClient.Update(GetBaseuRL(), $"/api/Persons/update/{Person.ID}", Person);

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
                        return View(Person);
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception er)
                {
                    er.LogError();
                }
            }
            return View(Person);

        }

        //GET - DELETE
        public async Task<IActionResult> DeleteRecord(string id, object data = null)
        {
            if (id == null || string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var result = await _apiClient.Get<PersonDto>(GetBaseuRL(), $"/api/Persons/getbyid/{id}");

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

            var result = await _apiClient.Delete<PersonDto>(GetBaseuRL(), $"/api/Persons/delete", id);

            if (!result.HasError)
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }

    }
}

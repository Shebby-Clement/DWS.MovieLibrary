using AutoMapper;
using DWS.MovieLibrary.Domain.Dtos;
using DWS.MovieLibrary.Domain.Models;
using DWS.MovieLibrary.Web.Controllers.Api;
using DWS.PersonLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace DWS.PersonLibrary.Web.Controllers.Api
{
    //[Authorize]
    [Route("api/Persons")]
    [ApiController]
    public class PersonsController : BaseController
    {
        #region Fields

        private readonly IPersonService _PersonService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public PersonsController(IMapper mapper, IPersonService PersonService) : base()
        {
            _mapper = mapper;
            _PersonService = PersonService;
        }

        #endregion

        #region Person OPERTAIONS api

        [Route("all")]
        [HttpGet]
        [ResponseType(typeof(List<PersonDto>))]
        public async Task<IActionResult> GetAll()
        {

            var data = _PersonService.GetAll();
            var dataDto = _mapper.Map<List<PersonDto>>(data);

            if (dataDto != null)
            {
                return Ok(dataDto);
            }

            return NotFound();
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(PersonDto))]
        public async Task<IActionResult> PostPerson(PersonDto PersonDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var Person = _mapper.Map<Person>(PersonDTO);

                _PersonService.CreatePerson(Person);

                _PersonService.Save();

                return Ok(PersonDTO);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [Route("getbyid/{PersonId}")]
        [HttpGet]
        [ResponseType(typeof(PersonDto))]
        public async Task<IActionResult> GetPerson(string PersonId)
        {
            var Person = _PersonService.GetPersonByID(PersonId);

            if (Person == null)
            {
                return NotFound();
            }

            var dataDto = _mapper.Map<PersonDto>(Person);

            return Ok(dataDto);
        }

        [Route("PersonsByFilter/{name}")]
        [HttpGet]
        [ResponseType(typeof(List<PersonDto>))]
        public async Task<IActionResult> GetPersonsByFilter(string name)
        {
            IEnumerable<Person> Persons = _PersonService.GetAll();

            if (Persons == null)
            {
                return NotFound();
            }


            if (!string.IsNullOrEmpty(name))
            {
                Persons = Persons.Where(t => t.FirstName.ToLower().Contains(name.ToLower())).ToList();
            }

            if (Persons == null)
            {
                return NotFound();
            }

            return Ok(Persons);

        }

        [Route("delete/{PersonId}")]
        [HttpDelete]
        [ResponseType(typeof(PersonDto))]
        public async Task<IActionResult> DeletePerson(string PersonId)
        {

            try
            {
                var PersonList = _PersonService.GetAll();

                var Person = PersonList.Where(m => m.ID == PersonId).SingleOrDefault();

                if (Person == null)
                {
                    return NotFound();
                }

                _PersonService.DeletePerson(PersonId);

                _PersonService.Save();

                return Ok($"Person with ID: {PersonId} has deleted");
            }
            catch (Exception error)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, error.Message);
            }
        }

        [Route("update/{PersonId}")]
        [ResponseType(typeof(PersonDto))]
        [HttpPut]
        public async Task<IActionResult> PutPerson(Guid PersonId, PersonDto PersonDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (PersonId != PersonDTO.ID)
            {
                return BadRequest();
            }


            try
            {
                var Person = _mapper.Map<Person>(PersonDTO);

                _PersonService.UpdatePerson(Person);

                _PersonService.Save();

                var dataDTO = _mapper.Map<PersonDto>(PersonDTO);

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

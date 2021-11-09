using DWS.MovieLibrary.Data.Interfaces;
using DWS.MovieLibrary.Data.Repositories.Interfaces;
using DWS.MovieLibrary.Domain.Models;
using DWS.PersonLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.PersonLibrary.Services.Implementation
{

    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPersonRepository personRepository;

        public PersonService(IUnitOfWork unitOfWork, IPersonRepository personRepository)
        {
            this.unitOfWork = unitOfWork;
            this.personRepository = personRepository;
        }

        public void CreatePerson(Person Person)
        {
            personRepository.Add(Person);
        }

        public Person GetPersonByID(string PersonId)
        {
            return personRepository.GetById(PersonId);
        }

        public void UpdatePerson(Person Person)
        {
            personRepository.Update(Person);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void DeletePerson(string PersonId)
        {
            personRepository.Delete(PersonId);
        }

        public IEnumerable<Person> GetAll()
        {
            return personRepository.GetAll();
        }


        public IEnumerable<Person> SearchPerson(string query)
        {
            return new List<Person>();
        }
    }
}

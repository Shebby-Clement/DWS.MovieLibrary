using DWS.MovieLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.PersonLibrary.Services.Interfaces
{
    public interface IPersonService
    {
        #region GENERAL CRUD
        Person GetPersonByID(string PersonId);
        void UpdatePerson(Person Person);
        void CreatePerson(Person Person);
        void DeletePerson(string PersonId);
        #endregion

        IEnumerable<Person> GetAll();
        IEnumerable<Person> SearchPerson(string query);
        void Save();
    }
}

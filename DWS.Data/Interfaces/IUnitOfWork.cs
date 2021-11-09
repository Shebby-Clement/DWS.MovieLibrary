using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.MovieLibrary.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}

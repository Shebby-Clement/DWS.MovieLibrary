using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.MovieLibrary.Domain.Models.Enum
{
 
    #region Application User
    public enum Role
    {
        Actor,
        Director
    }
    public enum Gender
    {
        Male,
        Famale,
        Other
    }
    public enum Country
    {
        China,
        Cuba,
        Egypt,
        Cyprus
    }

    public enum Category
    {
        Action,
        Comedy,
        Drama,
        Fantasy,
        Horror,
        Mystery,
        Romance
    }

    #endregion
}

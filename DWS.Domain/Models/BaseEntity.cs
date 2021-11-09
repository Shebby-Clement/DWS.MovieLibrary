using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.MovieLibrary.Domain.Models
{
    public abstract class BaseEntity<key> : IEntity<key>
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }
        public virtual key ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Elearn.Models
{
    public partial class UnitCategory
    {
        public UnitCategory()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public int Id { get; set; }
        public int UnitId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Elearn.Models
{
    public partial class Design
    {
        public Design()
        {
            Unit = new HashSet<Unit>();
        }

        public int Id { get; set; }
        public string Json { get; set; }

        public virtual ICollection<Unit> Unit { get; set; }
    }
}

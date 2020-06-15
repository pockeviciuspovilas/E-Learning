using System;
using System.Collections.Generic;

namespace Elearn.Model
{
    public partial class Test
    {
        public Test()
        {
            Asign = new HashSet<Asign>();
        }

        public int Id { get; set; }
        public string Json { get; set; }
        public string UserId { get; set; }
        public DateTime? InsertTime { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual TestCategory Category { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Asign> Asign { get; set; }
    }
}

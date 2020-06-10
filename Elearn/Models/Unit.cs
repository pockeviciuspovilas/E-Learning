using System;
using System.Collections.Generic;

namespace Elearn.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Subscription = new HashSet<Subscription>();
            TestCategory = new HashSet<TestCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public int? DesignId { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual Design Design { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Subscription> Subscription { get; set; }
        public virtual ICollection<TestCategory> TestCategory { get; set; }
    }
}

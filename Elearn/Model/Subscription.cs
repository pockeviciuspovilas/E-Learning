using System;
using System.Collections.Generic;

namespace Elearn.Model
{
    public partial class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Price { get; set; }
        public int UnitId { get; set; }

        public virtual Unit Unit { get; set; }
    }
}

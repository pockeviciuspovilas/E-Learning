using System;
using System.Collections.Generic;

namespace Elearn.Model
{
    public partial class Result
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime CompleteTime { get; set; }
        public double Mark { get; set; }
        public int AsignId { get; set; }
        public string Json { get; set; }

        public virtual Asign Asign { get; set; }
    }
}

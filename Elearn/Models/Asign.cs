using System;
using System.Collections.Generic;

namespace Elearn.Models
{
    public partial class Asign
    {
        public Asign()
        {
            Result = new HashSet<Result>();
        }

        public int Id { get; set; }
        public string AsignerId { get; set; }
        public string ApplicantId { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? TestId { get; set; }

        public virtual AspNetUsers Applicant { get; set; }
        public virtual AspNetUsers Asigner { get; set; }
        public virtual Test Test { get; set; }
        public virtual ICollection<Result> Result { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Elearn.Model
{
    public partial class TestCategory
    {
        public TestCategory()
        {
            Test = new HashSet<Test>();
        }

        public int Id { get; set; }
        public int UnitId { get; set; }
        public string Name { get; set; }

        public virtual Unit Unit { get; set; }
        public virtual ICollection<Test> Test { get; set; }
    }
}

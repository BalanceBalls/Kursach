using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursach.Models
{
    public class StepOfDevelopment
    {
        public int StepId { get; set; }

        public string StepName { get; set; }

        public string Description { get; set; }

        public DateTime EndDate { get; set; }

        public int StepProjectId { get; set; }
    }
}

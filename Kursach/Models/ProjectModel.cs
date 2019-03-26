using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursach.Models
{
    public class ProjectModel
    {
        public int Project { get; set; }

        public string ProjectName { get; set; }

        public double Cost { get; set; }
        
        public DateTime Deadline { get; set; }

        public bool IsDone { get; set; }

        public int AuthorId { get; set; }

        public List<StepOfDevelopmentModel> Steps { get; set; }
    }
}

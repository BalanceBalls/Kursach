using System;

namespace Kursach.Models
{
    public class StepOfDevelopmentModel
    {
        public int StepOfDevelopment { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime EndDate { get; set; }

        public int ProjectId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CourseRegistration.Core.DomainModel
{
    public class Registration
    {
        public Guid CourseId { get; set; }
        public string StudentEmail { get; set; }
    }
}

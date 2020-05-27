using System;
using System.Collections.Generic;
using System.Text;

namespace CourseRegistration.Core.DomainModel
{
    public class Student
    {
        public string Email { get;  }

        public Student(string email)
        {
            Email = email;
        }
    }
}

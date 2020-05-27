using System;
using System.Collections.Generic;
using System.Text;

namespace CourseRegistration.Core.DomainService
{
    public interface IPathRepository
    {
        string AppPath { get; }
    }
}

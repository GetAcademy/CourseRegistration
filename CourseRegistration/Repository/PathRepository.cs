using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseRegistration.Core.DomainService;

namespace CourseRegistration.Infrastructure.API.Repository
{
    public class PathRepository : IPathRepository
    {
        public string AppPath { get; }

        public PathRepository(string appPath)
        {
            AppPath = appPath;
        }
    }
}

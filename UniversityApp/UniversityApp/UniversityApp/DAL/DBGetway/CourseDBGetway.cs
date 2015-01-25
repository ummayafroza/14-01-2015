using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.DAL.DBGetway
{
    class CourseDBGetway
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["ConnectionStringForUniversityDB"].ConnectionString;
    }
}

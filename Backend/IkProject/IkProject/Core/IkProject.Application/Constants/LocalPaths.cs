using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Constants
{
    public static class LocalPaths
    {
        public static string ProjectPath = Directory.GetCurrentDirectory();
        public static string ProfileImage = ProjectPath + @"\wwwroot\images\profiles\";
        public static string ExpenseImage = ProjectPath + @"\wwwroot\images\expenses\";
        public static string CompanyImage = ProjectPath + @"\wwwroot\images\companies\";
        public static string PermissionImage = ProjectPath + @"\wwwroot\images\permissions\";
    }
}

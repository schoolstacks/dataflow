using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using transform_api_load_janitor.DataMaps.Interfaces;

namespace transform_api_load_janitor.DataMaps.StudentEnrollment
{

    public class Rootobject : IDataMap
    {
        public string EntityName { get; set; } = "studentSchoolAssociations";
        public string ApiVersion { get; set; } = "2.0";
        public Schoolreference schoolReference { get; set; }
        public Studentreference studentReference { get; set; }
        public Entrydate entryDate { get; set; }
        public Entrygradeleveldescriptor entryGradeLevelDescriptor { get; set; }
    }

    public class Schoolreference
    {
        public Schoolid schoolId { get; set; }
    }

    public class Schoolid
    {
        public string datatype { get; set; }
        public string source { get; set; }
        public string sourcetable { get; set; }
        public string sourcecolumn { get; set; }
    }

    public class Studentreference
    {
        public Studentuniqueid studentUniqueId { get; set; }
    }

    public class Studentuniqueid
    {
        public string datatype { get; set; }
        public string source { get; set; }
        public string sourcecolumn { get; set; }
    }

    public class Entrydate
    {
        public string datatype { get; set; }
        public string source { get; set; }
        public string sourcecolumn { get; set; }
    }

    public class Entrygradeleveldescriptor
    {
        public string datatype { get; set; }
        public string source { get; set; }
        public string sourcetable { get; set; }
        public string sourcecolumn { get; set; }
    }

}

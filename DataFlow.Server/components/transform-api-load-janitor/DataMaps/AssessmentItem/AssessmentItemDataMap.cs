using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using transform_api_load_janitor.DataMaps.Interfaces;

namespace transform_api_load_janitor.DataMaps.AssessmentItem
{

    public class Rootobject : IDataMap
    {
        public string EntityName { get; set; } = "assessmentItem";
        public string ApiVersion { get; set; } = "2.0";
        public Assessmentreference assessmentReference { get; set; }
        public Identificationcode identificationCode { get; set; }
    }

    public class Assessmentreference
    {
        public Title title { get; set; }
        public Assessedgradeleveldescriptor assessedGradeLevelDescriptor { get; set; }
        public Academicsubjectdescriptor academicSubjectDescriptor { get; set; }
        public Version version { get; set; }
    }

    public class Title
    {
        public string datatype { get; set; }
        public string source { get; set; }
        public string sourcecolumn { get; set; }
    }

    public class Assessedgradeleveldescriptor
    {
        public string datatype { get; set; }
        public string source { get; set; }
        public string sourcetable { get; set; }
        public string sourcecolumn { get; set; }
    }

    public class Academicsubjectdescriptor
    {
        public string datatype { get; set; }
        public string source { get; set; }
        public string value { get; set; }
    }

    public class Version
    {
        public string datatype { get; set; }
        public string source { get; set; }
        public string value { get; set; }
    }

    public class Identificationcode
    {
        public string datatype { get; set; }
        public string source { get; set; }
        public string sourcecolumn { get; set; }
    }

}

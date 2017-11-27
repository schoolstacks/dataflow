using DataFlow.Server.TransformLoad.DataMaps.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlow.Server.TransformLoad.Student
{

    public class StudentDataMap : IDataMap
    {
        public string EntityName { get; set; } = "students";
        public string ApiVersion { get; set; } = "2.0";
        public Studentuniqueid studentUniqueId { get; set; }
        public Firstname firstName { get; set; }
        public Lastsurname lastSurname { get; set; }
        public Sextype sexType { get; set; }
        public Birthdate birthDate { get; set; }
        public Hispaniclatinoethnicity hispanicLatinoEthnicity { get; set; }
    }

    public class Studentuniqueid
    {
        public string datatype { get; set; }
        public string source { get; set; }
        public string sourcecolumn { get; set; }
    }

    public class Firstname
    {
        public string datatype { get; set; }
        public string source { get; set; }
        public string sourcecolumn { get; set; }
    }

    public class Lastsurname
    {
        public string datatype { get; set; }
        public string source { get; set; }
        public string sourcecolumn { get; set; }
    }

    public class Sextype
    {
        public string datatype { get; set; }
        public string source { get; set; }
        public string sourcetable { get; set; }
        public string sourcecolumn { get; set; }
    }

    public class Birthdate
    {
        public string datatype { get; set; }
        public string source { get; set; }
        public string sourcecolumn { get; set; }
    }

    public class Hispaniclatinoethnicity
    {
        public string datatype { get; set; }
        public string source { get; set; }
        public string sourcetable { get; set; }
        public string sourcecolumn { get; set; }
        public string _default { get; set; }
    }

}

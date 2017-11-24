using Newtonsoft.Json;

namespace DataFlow.EdFi.Models.Resources 
{
    public class SchoolGradeLevel 
    {
        /// <summary>
        /// The grade levels served at the school.
        /// </summary>
        [JsonProperty(PropertyName = "gradeLevelDescriptor")]
        public string GradeLevelDescriptor { get; set; }

        }
}


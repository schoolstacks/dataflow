using System;

namespace DataFlow.EdFi.Models.AssessmentComposite 
{
    public class StudentAssessment_student 
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.
        /// </summary>
        public string firstName { get; set; }

        /// <summary>
        /// The name borne in common by members of a family.
        /// </summary>
        public string lastSurname { get; set; }

        /// <summary>
        /// The month, day, and year on which an individual was born.
        /// </summary>
        public DateTime? birthDate { get; set; }

        }
}


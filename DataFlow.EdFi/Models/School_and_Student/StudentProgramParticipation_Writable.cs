using System;
using System.Collections.Generic;

namespace DataFlow.EdFi.Models.School_and_Student 
{
    public class StudentProgramParticipation_Writable 
    {
        /// <summary>
        /// The program the student is associated with or receiving services from.
        /// </summary>
        public string programType { get; set; }

        /// <summary>
        /// The date the Student was associated with the Program or service.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// The date the Program participation ended.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The person, organization, or department that made a student designation.
        /// </summary>
        public string designatedBy { get; set; }

        /// <summary>
        /// An unordered collection of studentProgramParticipationProgramCharacteristics.  Reflects important characteristics of the Program that a Student participates in, such as categories or particular indications.
        /// </summary>
        public List<StudentProgramParticipationProgramCharacteristic_Writable> programCharacteristics { get; set; }

        }
}


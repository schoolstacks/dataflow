using System;

namespace DataFlow.EdFi.Models.EnrollmentComposite 
{
    public class SectionEnrollment_studentSectionAssociation_studentProgramParticipation 
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

        }
}


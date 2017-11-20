using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class GraduationPlan 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related EducationOrganization resource.
        /// </summary>
        public EducationOrganizationReference educationOrganizationReference { get; set; }

        /// <summary>
        /// A reference to the related SchoolYearType resource.
        /// </summary>
        public SchoolYearTypeReference graduationSchoolYearTypeReference { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string typeDescriptor { get; set; }

        /// <summary>
        /// An indicator of whether the GraduationPlan is tailored for an individual.
        /// </summary>
        public bool? individualPlan { get; set; }

        /// <summary>
        /// The total number of credits required for graduation under this plan.
        /// </summary>
        public double? totalRequiredCredits { get; set; }

        /// <summary>
        /// Key for Credit
        /// </summary>
        public string totalRequiredCreditType { get; set; }

        /// <summary>
        /// Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.
        /// </summary>
        public double? totalRequiredCreditConversion { get; set; }

        /// <summary>
        /// An unordered collection of graduationPlanCreditsByCourses.  The total credits required for graduation by taking a specific course, or by taking one or more from a set of courses.
        /// </summary>
        public List<GraduationPlanCreditsByCourse> creditsByCourses { get; set; }

        /// <summary>
        /// An unordered collection of graduationPlanCreditsBySubjects.  The total number of credits required in a subject to graduate.  Only those courses identified as a high school course requirement are eligible to meet subject credit requirements.
        /// </summary>
        public List<GraduationPlanCreditsBySubject> creditsBySubjects { get; set; }

        /// <summary>
        /// An unordered collection of graduationPlanRequiredAssessments.  The total credits required for graduation by taking a specific course, or by taking one or more from a set of courses.
        /// </summary>
        public List<GraduationPlanRequiredAssessment> requiredAssessments { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}


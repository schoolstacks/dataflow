using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentSpecialEducationProgramAssociation 
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
        /// A reference to the related Program resource.
        /// </summary>
        public ProgramReference programReference { get; set; }

        /// <summary>
        /// A reference to the related Student resource.
        /// </summary>
        public StudentReference studentReference { get; set; }

        /// <summary>
        /// The month, day, and year on which the Student first received services.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// The month, day, and year on which the Student exited the Program or stopped receiving services.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string reasonExitedDescriptor { get; set; }

        /// <summary>
        /// Indicates whether the Student received services during the summer session or between sessions.
        /// </summary>
        public bool? servedOutsideOfRegularSession { get; set; }

        /// <summary>
        /// Indicator of the eligibility of the student to receive special education services according to the Individuals with Disabilities Education Act (IDEA).
        /// </summary>
        public bool? ideaEligibility { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string specialEducationSettingDescriptor { get; set; }

        /// <summary>
        /// The number of hours per week for special education instruction and therapy.
        /// </summary>
        public double? specialEducationHoursPerWeek { get; set; }

        /// <summary>
        /// Indicate the total number of hours of instructional time per week for the school that the student attends.
        /// </summary>
        public double? schoolHoursPerWeek { get; set; }

        /// <summary>
        /// Indicates whether the Student receiving special education and related services has been designated as multiply disabled by the admission, review, and dismissal committee as aligned with federal requirements.
        /// </summary>
        public bool? multiplyDisabled { get; set; }

        /// <summary>
        /// Indicates whether the Student receiving special education and related services is: 1) in the age range of birth to 22 years, and 2) has a serious, ongoing illness or a chronic condition that has lasted or is anticipated to last at least 12 or more months or has required at least one month of hospitalization, and that requires daily, ongoing medical treatments and monitoring by appropriately trained personnel which may include parents or other family members, and 3) requires the routine use of medical device or of assistive technology to compensate for the loss of usefulness of a body function needed to participate in activities of daily living, and 4) lives with ongoing threat to his or her continued well-being. Aligns with federal requirements.
        /// </summary>
        public bool? medicallyFragile { get; set; }

        /// <summary>
        /// The date of the last special education evaluation.
        /// </summary>
        public DateTime? lastEvaluationDate { get; set; }

        /// <summary>
        /// The date of the last IEP review.
        /// </summary>
        public DateTime? iepReviewDate { get; set; }

        /// <summary>
        /// The effective date of the most recent IEP.
        /// </summary>
        public DateTime? iepBeginDate { get; set; }

        /// <summary>
        /// The end date of the most recent IEP.
        /// </summary>
        public DateTime? iepEndDate { get; set; }

        /// <summary>
        /// An unordered collection of studentProgramAssociationServices.  Indicates the services being provided to the student by the program.
        /// </summary>
        public List<StudentProgramAssociationService> services { get; set; }

        /// <summary>
        /// An unordered collection of studentSpecialEducationProgramAssociationServiceProviders.  The staff providing Special Education services to the student.
        /// </summary>
        public List<StudentSpecialEducationProgramAssociationServiceProvider> serviceProviders { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}


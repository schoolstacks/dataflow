using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentAcademicRecord 
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
        public SchoolYearTypeReference schoolYearTypeReference { get; set; }

        /// <summary>
        /// A reference to the related Student resource.
        /// </summary>
        public StudentReference studentReference { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string termDescriptor { get; set; }

        /// <summary>
        /// Key for Credit
        /// </summary>
        public string cumulativeEarnedCreditType { get; set; }

        /// <summary>
        /// Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.
        /// </summary>
        public double? cumulativeEarnedCreditConversion { get; set; }

        /// <summary>
        /// The cumulative number of credits an individual earns by completing courses or examinations during his or her enrollment in the current school as well as those credits transferred from schools in which the individual had been previously enrolled.
        /// </summary>
        public double? cumulativeEarnedCredits { get; set; }

        /// <summary>
        /// Key for Credit
        /// </summary>
        public string cumulativeAttemptedCreditType { get; set; }

        /// <summary>
        /// Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.
        /// </summary>
        public double? cumulativeAttemptedCreditConversion { get; set; }

        /// <summary>
        /// The cumulative number of credits an individual attempts to earn by taking courses during his or her enrollment in the current school as well as those credits transferred from schools in which the individual had been previously enrolled.
        /// </summary>
        public double? cumulativeAttemptedCredits { get; set; }

        /// <summary>
        /// The cumulative number of grade points an individual earns by successfully completing courses or examinations during his or her enrollment in the current school as well as those transferred from schools in which the individual had been previously enrolled.
        /// </summary>
        public double? cumulativeGradePointsEarned { get; set; }

        /// <summary>
        /// A measure of average performance in all courses taken by an individual during his or her school career as determined for record-keeping purposes. This is obtained by dividing the total grade points received by the total number of credits attempted. This usually includes grade points received and credits attempted in his or her current school as well as those transferred from schools in which the individual was previously enrolled.
        /// </summary>
        public double? cumulativeGradePointAverage { get; set; }

        /// <summary>
        /// The scale of equivalents, if applicable, for grades awarded as indicators of performance in schoolwork. For example, numerical equivalents for letter grades used in determining a student's Grade Point Average (A=4, B=3, C=2, D=1 in a four-point system) or letter equivalents for percentage grades (90-100%=A, 80-90%=B, etc.).
        /// </summary>
        public string gradeValueQualifier { get; set; }

        /// <summary>
        /// The month and year the student is projected to graduate.
        /// </summary>
        public DateTime? projectedGraduationDate { get; set; }

        /// <summary>
        /// Key for Credit
        /// </summary>
        public string sessionEarnedCreditType { get; set; }

        /// <summary>
        /// Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.
        /// </summary>
        public double? sessionEarnedCreditConversion { get; set; }

        /// <summary>
        /// The number of an credits an individual earned in this session.
        /// </summary>
        public double? sessionEarnedCredits { get; set; }

        /// <summary>
        /// Key for Credit
        /// </summary>
        public string sessionAttemptedCreditType { get; set; }

        /// <summary>
        /// Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.
        /// </summary>
        public double? sessionAttemptedCreditConversion { get; set; }

        /// <summary>
        /// The number of an credits an individual attempted to earn in this session.
        /// </summary>
        public double? sessionAttemptedCredits { get; set; }

        /// <summary>
        /// The number of grade points an individual earned for this session.
        /// </summary>
        public double? sessionGradePointsEarned { get; set; }

        /// <summary>
        /// The grade point average for an individual computed as the grade points earned during the session divided by the number of credits attempted.
        /// </summary>
        public double? sessionGradePointAverage { get; set; }

        /// <summary>
        /// The academic rank information of a student in relation to his or her graduating class
        /// </summary>
        public StudentAcademicRecordClassRanking classRanking { get; set; }

        /// <summary>
        /// An unordered collection of studentAcademicRecordAcademicHonors.  
        /// </summary>
        public List<StudentAcademicRecordAcademicHonor> academicHonors { get; set; }

        /// <summary>
        /// An unordered collection of studentAcademicRecordDiplomas.  This educational entity represents the conferring or certification by an educational organization that the student has successfully completed a particular course of study. It represents the electronic version of its physical document counterpart.
        /// </summary>
        public List<StudentAcademicRecordDiploma> diplomas { get; set; }

        /// <summary>
        /// An unordered collection of studentAcademicRecordRecognitions.  Recognition given to the student for accomplishments in a co-curricular or extra-curricular activity.
        /// </summary>
        public List<StudentAcademicRecordRecognition> recognitions { get; set; }

        /// <summary>
        /// An unordered collection of studentAcademicRecordReportCards.  Report cards for the student.
        /// </summary>
        public List<StudentAcademicRecordReportCard> reportCards { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}


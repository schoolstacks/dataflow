using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class StudentAcademicRecordAcademicHonor 
    {
        /// <summary>
        /// A designation of the type of academic distinctions earned by or awarded to the student.
        /// </summary>
        public string academicHonorCategoryType { get; set; }

        /// <summary>
        /// A description of the type of academic distinctions earned by or awarded to the individual.
        /// </summary>
        public string honorDescription { get; set; }

        /// <summary>
        /// The date the honor was awarded or earned.
        /// </summary>
        public DateTime? honorAwardDate { get; set; }

        /// <summary>
        /// Date on which the award expires.
        /// </summary>
        public DateTime? honorAwardExpiresDate { get; set; }

        /// <summary>
        /// The title assigned to the achievement.
        /// </summary>
        public string achievementTitle { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string achievementCategoryDescriptor { get; set; }

        /// <summary>
        /// The system that defines the categories by which an achievement is attributed to the learner.
        /// </summary>
        public string achievementCategorySystem { get; set; }

        /// <summary>
        /// The name of the agent issuing the award.
        /// </summary>
        public string issuerName { get; set; }

        /// <summary>
        /// The Uniform Resource Locator (URL) from which the award was issued.
        /// </summary>
        public string issuerOriginURL { get; set; }

        /// <summary>
        /// The criteria for competency-based completion of the achievement/award.
        /// </summary>
        public string criteria { get; set; }

        /// <summary>
        /// The Uniform Resource Locator (URL) for the unique address of a web page describing the competency-based completion criteria for the achievement/award.
        /// </summary>
        public string criteriaURL { get; set; }

        /// <summary>
        /// A statement or reference describing the evidence that the learner met the criteria for attainment of the achievement.
        /// </summary>
        public string evidenceStatement { get; set; }

        /// <summary>
        /// The Uniform Resource Locator (URL) for the unique address of an image representing an award or badge associated with the achievement.
        /// </summary>
        public string imageURL { get; set; }

        }
}


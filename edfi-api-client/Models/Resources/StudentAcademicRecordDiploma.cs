using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentAcademicRecordDiploma 
    {
        /// <summary>
        /// The type of diploma/credential that is awarded to a student in recognition of his/her completion of the curricular requirements.
        /// </summary>
        public string diplomaType { get; set; }

        /// <summary>
        /// The month, day, and year on which the student met graduation requirements and was awarded a diploma.
        /// </summary>
        public DateTime? diplomaAwardDate { get; set; }

        /// <summary>
        /// The type of diploma/credential that is awarded to a student in recognition of his/her completion of the curricular requirements.  Minimum high school program  Recommended high school program  Distinguished Achievement Program
        /// </summary>
        public string diplomaLevelType { get; set; }

        /// <summary>
        /// Indicated a student who reached a state-defined threshold of vocational education and who attained a high school diploma or its recognized state equivalent or GED.
        /// </summary>
        public bool? cteCompleter { get; set; }

        /// <summary>
        /// The description of diploma given to the student for accomplishments.
        /// </summary>
        public string diplomaDescription { get; set; }

        /// <summary>
        /// Date on which the award expires.
        /// </summary>
        public DateTime? diplomaAwardExpiresDate { get; set; }

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


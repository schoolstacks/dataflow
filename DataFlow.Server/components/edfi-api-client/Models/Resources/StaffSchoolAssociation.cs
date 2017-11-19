using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StaffSchoolAssociation 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related School resource.
        /// </summary>
        public SchoolReference schoolReference { get; set; }

        /// <summary>
        /// A reference to the related SchoolYearType resource.
        /// </summary>
        public SchoolYearTypeReference schoolYearTypeReference { get; set; }

        /// <summary>
        /// A reference to the related Staff resource.
        /// </summary>
        public StaffReference staffReference { get; set; }

        /// <summary>
        /// The name of the program for which the individual is assigned; for example:  Regular education  Title I-Academic  Title I-Non-Academic  Special Education  Bilingual/English as a Second Language  NEDM: Program Assignment
        /// </summary>
        public string programAssignmentDescriptor { get; set; }

        /// <summary>
        /// An unordered collection of staffSchoolAssociationAcademicSubjects.  The teaching field taught by an individual: for example: English/Language Arts, Reading, Mathematics, Science, Social Sciences, etc.
        /// </summary>
        public List<StaffSchoolAssociationAcademicSubject> academicSubjects { get; set; }

        /// <summary>
        /// An unordered collection of staffSchoolAssociationGradeLevels.  The set of grade levels for which the individual's assignment is responsible.
        /// </summary>
        public List<StaffSchoolAssociationGradeLevel> gradeLevels { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}


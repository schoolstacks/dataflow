using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentCTEProgramAssociationCTEProgram 
    {
        /// <summary>
        /// The career cluster representing the career path of the Vocational/Career Tech concentrator.  NEDM: Career Cluster
        /// </summary>
        public string careerPathwayType { get; set; }

        /// <summary>
        /// Number and description of the CIP Code associated with the student's CTE program.
        /// </summary>
        public string cipCode { get; set; }

        /// <summary>
        /// A boolean indicator of whether this CTEProgram, is the student's primary CTEProgram.
        /// </summary>
        public bool? primaryCTEProgramIndicator { get; set; }

        /// <summary>
        /// A boolean indicator of whether the Student has completed the CTEProgram.
        /// </summary>
        public bool? cteProgramCompletionIndicator { get; set; }

        }
}


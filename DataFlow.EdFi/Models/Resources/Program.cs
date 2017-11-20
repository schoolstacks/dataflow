using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class Program 
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
        /// Key for Program
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// The formal name of the program of instruction, training, services or benefits available through federal, state, or local agencies.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to a program by a school, school system, a state, or other agency or entity.
        /// </summary>
        public string programId { get; set; }

        /// <summary>
        /// Key for ProgramSponsor
        /// </summary>
        public string sponsorType { get; set; }

        /// <summary>
        /// An unordered collection of programCharacteristics.  Reflects important characteristics of the Program, such as categories or particular indications.
        /// </summary>
        public List<ProgramCharacteristic> characteristics { get; set; }

        /// <summary>
        /// An unordered collection of programLearningObjectives.  Learning Standard followed by this program.
        /// </summary>
        public List<ProgramLearningObjective> learningObjectives { get; set; }

        /// <summary>
        /// An unordered collection of programLearningStandards.  References the Learning Objective(s) the Program is associated with.
        /// </summary>
        public List<ProgramLearningStandard> learningStandards { get; set; }

        /// <summary>
        /// An unordered collection of programServices.  Defines the services this program provides to students.
        /// </summary>
        public List<ProgramService> services { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}


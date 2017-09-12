using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class Parent 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A unique alphanumeric code assigned to a parent.
        /// </summary>
        public string parentUniqueId { get; set; }

        /// <summary>
        /// A prefix used to denote the title, degree, position, or seniority of the person.
        /// </summary>
        public string personalTitlePrefix { get; set; }

        /// <summary>
        /// A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.
        /// </summary>
        public string firstName { get; set; }

        /// <summary>
        /// A secondary name given to an individual at birth, baptism, or during another naming ceremony.
        /// </summary>
        public string middleName { get; set; }

        /// <summary>
        /// The name borne in common by members of a family.
        /// </summary>
        public string lastSurname { get; set; }

        /// <summary>
        /// An appendage, if any, used to denote an individual's generation in his family (e.g., Jr., Sr., III).
        /// </summary>
        public string generationCodeSuffix { get; set; }

        /// <summary>
        /// The person's maiden name.
        /// </summary>
        public string maidenName { get; set; }

        /// <summary>
        /// A person''s gender.
        /// </summary>
        public string sexType { get; set; }

        /// <summary>
        /// The login ID for the user; used for security access control interface.
        /// </summary>
        public string loginId { get; set; }

        /// <summary>
        /// An unordered collection of parentAddresses.  Parent's address, if different from the student address.
        /// </summary>
        public List<ParentAddress> addresses { get; set; }

        /// <summary>
        /// An unordered collection of parentElectronicMails.  The numbers, letters and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.
        /// </summary>
        public List<ParentElectronicMail> electronicMails { get; set; }

        /// <summary>
        /// An unordered collection of parentIdentificationDocuments.  This type represents the valid document that a person uses for identification.
        /// </summary>
        public List<ParentIdentificationDocument> identificationDocuments { get; set; }

        /// <summary>
        /// An unordered collection of parentInternationalAddresses.  Parent's address, if different from the student address.
        /// </summary>
        public List<ParentInternationalAddress> internationalAddresses { get; set; }

        /// <summary>
        /// An unordered collection of parentOtherNames.  Other names (e.g., alias, nickname, previous legal name) associated with a person.
        /// </summary>
        public List<ParentOtherName> otherNames { get; set; }

        /// <summary>
        /// An unordered collection of parentTelephones.  The 10-digit telephone number, including the area code, for the person.
        /// </summary>
        public List<ParentTelephone> telephones { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}


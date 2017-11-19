using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Sdk
{
    public class IdentityResource 
    {
        public string UniqueId { get; set; }

        public string BirthGender { get; set; }

        public DateTime? BirthDate { get; set; }

        public string FamilyNames { get; set; }

        public string GivenNames { get; set; }

        public double? Weight { get; set; }

        public SchoolAssociationResource SchoolAssociation { get; set; }

        }
}



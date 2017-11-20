using System;

namespace DataFlow.EdFi.Sdk
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



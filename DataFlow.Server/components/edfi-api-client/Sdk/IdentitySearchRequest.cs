using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Sdk
{
    public class IdentitySearchRequest 
    {
        public string LastSurname { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string GenerationCodeSuffix { get; set; }

        public string SexType { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? BirthOrder { get; set; }

        public IdentityLocation BirthLocation { get; set; }

        }
}



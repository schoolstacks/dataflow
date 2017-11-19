using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StaffRace 
    {
        /// <summary>
        /// The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.        AMERICAN-INDIAN-ALASKA-NATIVE-CODE        ASIAN-CODE        BLACK-AFRICAN-AMERICAN-CODE        NATIVE-HAWAIIAN-PACIFIC-ISLANDER-CODE        WHITE-CODE
        /// </summary>
        public string raceType { get; set; }

        }
}


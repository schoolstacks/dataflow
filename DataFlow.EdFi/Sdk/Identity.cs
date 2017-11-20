namespace DataFlow.EdFi.Sdk
{
    public class Identity
    {
        public string uniqueId { get; set; }
        public string familyNames { get; set; }
        public string givenNames { get; set; }
        public string birthGender { get; set; }
        public string birthDate { get; set; }
        public decimal? weight { get; set; }
        public bool? isMatch { get; set; }
        public SchoolAssociationResource SchoolAssociation { get; set; }
    }
}


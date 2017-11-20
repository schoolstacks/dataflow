namespace DataFlow.EdFi.Models.Resources 
{
    public class StudentSpecialEducationProgramAssociationServiceProvider 
    {
        /// <summary>
        /// A reference to the related Staff resource.
        /// </summary>
        public StaffReference staffReference { get; set; }

        /// <summary>
        /// Primary ServiceProvider.
        /// </summary>
        public bool? primaryProvider { get; set; }

        }
}


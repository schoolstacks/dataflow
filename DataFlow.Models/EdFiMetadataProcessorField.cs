using System.Collections.Generic;

namespace DataFlow.Models
{
    public class EdFiMetadataProcessorField
    {
        public EdFiMetadataProcessorField()
        {
            SubFields = new List<EdFiMetadataProcessorField>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public bool Required { get; set; }

        public List<EdFiMetadataProcessorField> SubFields { get; set; }
    }
}

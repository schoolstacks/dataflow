using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class ProcessedDataMap : EntityTypeConfiguration<ProcessedData>
    {
        public ProcessedDataMap()
        {
            this.ToTable("ProcessedData");
            this.HasKey(x => x.Id);

            /* this.Property(e => e.Base64HashedString)
                .IsRequired()
                .HasColumnName("base64HashedString"); */
        }
    }
}
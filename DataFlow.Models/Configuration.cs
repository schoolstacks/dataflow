using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFlow.Models
{
    public partial class Configuration
    {
        [Key, MaxLength(255)]
        public string Key { get; set; }

        [MaxLength(1024)]
        public string Value { get; set; }
    }
}

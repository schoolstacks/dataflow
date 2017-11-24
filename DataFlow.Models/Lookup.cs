using System.ComponentModel.DataAnnotations;

namespace DataFlow.Models
{
    public partial class Lookup
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a group set.")]
        [Display(Name = "Group Set")]
        public string GroupSet { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a key.")]
        public string Key { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a value for the key.")]
        public string Value { get; set; }
    }
}

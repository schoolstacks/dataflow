namespace DataFlow.Models
{
    public partial class AspNetUserRole
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public AspNetRole Role { get; set; }
        public AspNetUser User { get; set; }
    }
}

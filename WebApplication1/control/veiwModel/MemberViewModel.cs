namespace WebApplication1.control.veiwModel
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        public string? MemberTypeCode { get; set; }
        public string? MemberName { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

    }
    public class ListMember {   
        public int Id { get; set; }
        public string? MemberTypeCode { get; set; }
        public string MemberTypeName { get; set; }
        public string? MemberName { get; set;}
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool? Active { get; set; }
    }
}

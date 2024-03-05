using WebApplication1.Models;

namespace WebApplication1.control.veiwModel
{
    public class MemberTypeViewModel
    {
        public string MemberTypeCode { get; set; } = null!;

        public string? MemberTypeName { get; set; }

        public bool? Active { get; set; }
    }
}

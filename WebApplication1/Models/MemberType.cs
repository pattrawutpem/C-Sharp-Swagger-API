using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class MemberType
{
    public string MemberTypeCode { get; set; } = null!;

    public string? MemberTypeName { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}

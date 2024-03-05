using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Member
{
    public int Id { get; set; }

    public string MemberTypeCode { get; set; } = null!;

    public string? MemberName { get; set; }

    public string? Mobile { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public virtual MemberType MemberTypeCodeNavigation { get; set; } = null!;
}

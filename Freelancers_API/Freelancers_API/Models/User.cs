using System;
using System.Collections.Generic;

namespace Freelancers_API.Models;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string? Mail { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Skillsets { get; set; }

    public string? Hobby { get; set; }
}

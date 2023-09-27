using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YelpAgainstCompanies.Domain.Entities;

[ExcludeFromCodeCoverage]
public class RefreshToken
{
    public string UserName { get; set; }

    public string TokenString { get; set; }

    public DateTime ExpireAt { get; set; }
}

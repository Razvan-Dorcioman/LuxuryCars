using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LuxuryCars.Models.Entities
{
    public class User : IdentityUser
    {
        public bool Admin { get; set; }
        public bool Telemetry { get; set; }
    }
}

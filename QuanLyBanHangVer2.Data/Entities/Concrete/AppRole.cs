

using Microsoft.AspNetCore.Identity;
using System;

namespace QuanLyBanHangVer2.Data.Entities.Concrete
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}

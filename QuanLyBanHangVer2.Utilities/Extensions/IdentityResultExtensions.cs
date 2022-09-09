using Microsoft.AspNetCore.Identity;
using QuanLyBanHangVer2.Application.Catalog.Manage.Products;
using QuanLyBanHangVer2.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.Utilities.Extensions
{
    public static class IdentityResultExtensions
    {
        public static void CheckErrors(this IdentityResult identityResult)
        {
            if (identityResult.Succeeded)
            {
                return;
            }
            throw new QuanLyBanHangVer2Exception(identityResult.Errors.Select(err => err.Description).JoinAsString(", "));
        }
    }
}

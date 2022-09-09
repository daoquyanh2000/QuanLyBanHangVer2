using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.ViewModel.Common.Request
{
    public class PagingRequestBase
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

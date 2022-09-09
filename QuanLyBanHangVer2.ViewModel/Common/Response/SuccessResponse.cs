using QuanLyBanHangVer2.ViewModel.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.ViewModel.Common.Api
{
    public class SuccessResponse<T> : ResponseBase<T>
    {
        public SuccessResponse(T data) :base(data)
        {
            Succeeded = true;
            Errors = null;
            Message= string.Empty;
        }

        public SuccessResponse()
        {
            Succeeded = true;
        }
    }
}

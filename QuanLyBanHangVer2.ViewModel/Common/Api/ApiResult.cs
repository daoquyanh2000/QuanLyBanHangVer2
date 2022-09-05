using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.ViewModel.Common.Api
{
    public class ApiResult<T>
    {
        public bool IsSuccessed { get; set; }
        public string Message { get; set; }
        public T Items { get; set; }
    }

    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult(T items)
        {
            Items = items;
            IsSuccessed = true;
        }

        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }
    }

    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[] ValidationErrors { get; set; }

        public ApiErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }

        public ApiErrorResult(string[] validationErrors)
        {
            ValidationErrors = validationErrors;
            IsSuccessed = false;
        }

        public ApiErrorResult()
        {
        }
    }
}
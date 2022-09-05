using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.ViewModel.Common
{
    public class ApiResult<T>
    {
        public ApiResult(bool isSuccessed, T items)
        {
            Items = items;
            IsSuccessed = isSuccessed;
        }

        public ApiResult(bool isSuccessed, IList<ErrorBase> errors)
        {
            IsSuccessed = isSuccessed;
            Errors = errors;
        }

        public T Items { get; set; }
        public bool IsSuccessed { get; set; }
        public IList<ErrorBase> Errors { get; set; }
    }
}
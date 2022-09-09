using QuanLyBanHangVer2.ViewModel.Common.Paging;
using QuanLyBanHangVer2.ViewModel.Common.Request;

namespace QuanLyBanHangVer2.ViewModel.System.Users
{
    public class UserPagingRequest :PagingRequestBase
    {
        public string keyword { get; set; }
    }
}
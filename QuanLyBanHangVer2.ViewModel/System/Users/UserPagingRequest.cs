using QuanLyBanHangVer2.ViewModel.Common;

namespace QuanLyBanHangVer2.ViewModel.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
    }
}
using QuanLyBanHangVer2.ViewModel.Common.Response;

namespace QuanLyBanHangVer2.ViewModel.Common.Paging
{
    public class PagedResponse<T> : ResponseBase<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize) : base(data)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Message = string.Empty;
            Succeeded = true;
            Errors = null;
        }
    }
}
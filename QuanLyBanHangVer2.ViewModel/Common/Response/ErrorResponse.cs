using QuanLyBanHangVer2.ViewModel.Common.Response;

namespace QuanLyBanHangVer2.ViewModel.Common.ApiResult
{
    public class ErrorResponse<T> : ResponseBase<T>
    {
        public string[] ValidationErrors { get; set; }

        public ErrorResponse(string message)
        {
            Succeeded = false;
            Message = message;
        }

        public ErrorResponse(string[] validationErrors)
        {
            ValidationErrors = validationErrors;
            Succeeded = false;
        }

        public ErrorResponse()
        {
        }
    }
}
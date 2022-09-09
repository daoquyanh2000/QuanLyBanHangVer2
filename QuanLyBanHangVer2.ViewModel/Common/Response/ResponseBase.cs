namespace QuanLyBanHangVer2.ViewModel.Common.Response
{
    public class ResponseBase<T>
    {
        public ResponseBase()
        {
        }

        public ResponseBase(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}
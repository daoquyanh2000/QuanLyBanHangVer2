using System;
using System.Runtime.Serialization;

namespace QuanLyBanHangVer2.Application.Catalog.Manage.Products
{
    [Serializable]
    public class QuanLyBanHangVer2Exception : Exception
    {
        public QuanLyBanHangVer2Exception()
        {
        }

        public QuanLyBanHangVer2Exception(string message) : base(message)
        {
        }

        public QuanLyBanHangVer2Exception(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected QuanLyBanHangVer2Exception(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
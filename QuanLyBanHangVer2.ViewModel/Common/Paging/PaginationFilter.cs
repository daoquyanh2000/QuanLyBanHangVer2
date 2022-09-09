using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.ViewModel.Common.Paging
{
    public class PaginationFilter
    {
        private readonly int _defaultPageSize = 50;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = _defaultPageSize;
        }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > _defaultPageSize ? _defaultPageSize : pageSize;
        }
    }
}
﻿using QuanLyBanHangVer2.ViewModel.Catalog.Products;
using QuanLyBanHangVer2.ViewModel.Common;
using QuanLyBanHangVer2.ViewModel.Common.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.Application.Catalog.Products.Public
{
    public interface IPulbicProductService
    {
        Task<PagedResponse<List<ProductViewModel>>> GetAllPagingPublicAsync(PublicProductPagingRequest request);
        Task<List<ProductViewModel>> GetAll();

    }
}

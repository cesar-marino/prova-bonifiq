﻿using ProvaPub.Application.Commons;
using ProvaPub.Application.UseCases.Product.Commons;

namespace ProvaPub.Application.UseCases.Product.ListProducts
{
    public class ListProductsResponse(
        int page,
        int perPage,
        List<ProductResponse> items) : PaginationResponse<ProductResponse>(
            page,
            perPage,
            items)
    {
    }
}

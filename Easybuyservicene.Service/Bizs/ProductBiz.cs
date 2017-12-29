using Easybuyservicene.Service.DataAccess;
using Easybuyservicene.Service.Dtos;
using Easybuyservicene.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Bizs
{
    public class ProductBiz
    {
        public static QueryResponseDTO<List<ProductModel>> GetProductInfo(ProductDTO dto)
        {
            return ProductDA.GetProductInfo(dto);
        }

        public static QueryResponseDTO<bool> AlterProductInfo(ProductDTO dto)
        {
            return ProductDA.AlterProductInfo(dto.ProductModel);
        }

        public static QueryResponseDTO<bool> AlterProductStock(ProductDTO dto)
        {
            return ProductDA.AlterProductStock(dto.ProductModel);
        }

        public static QueryResponseDTO<bool> AddProductInfo(ProductDTO dto)
        {
            return ProductDA.AddProductInfo(dto);
        }

        public static QueryResponseDTO<bool> DeleteProductInfo(ProductDTO dto)
        {
            return ProductDA.DeleteProductInfo(dto);
        }
    }
}

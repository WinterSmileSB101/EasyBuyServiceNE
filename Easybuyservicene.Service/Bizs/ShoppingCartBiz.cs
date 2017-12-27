using Easybuyservicene.Service.DataAccess;
using Easybuyservicene.Service.Dtos;
using Easybuyservicene.Service.Dtos.ShoppingCart;
using Easybuyservicene.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Bizs
{
    public class ShoppingCartBiz
    {
        public static QueryResponseDTO<List<ShoppingCartModel>> GetShoppingCartInfo(ShoppingCartDTO dto)
        {
            return ShoppingCartDA.GetShoppingCartInfo(dto);
        }

        public static QueryResponseDTO<bool> AlterShoppingCartInfo(ShoppingCartDTO dto)
        {
            return ShoppingCartDA.AlterShoppingCartInfo(dto);
        }

        public static QueryResponseDTO<bool> AddShoppingCartInfo(ShoppingCartDTO dto)
        {
            return ShoppingCartDA.AddShoppingCartInfo(dto);
        }

        public static QueryResponseDTO<bool> DeleteShoppingCartInfo(ShoppingCartDTO dto)
        {
            return ShoppingCartDA.DeleteShoppingCartInfo(dto);
        }
    }
}

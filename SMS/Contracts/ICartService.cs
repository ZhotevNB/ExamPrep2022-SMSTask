using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contracts
{
    public interface ICartService
    {
        (bool productIsAddedToCart, string error) AddProductToCart(string productId, string userID);

        IEnumerable<CartListProductsViewModel> GetAllCartProducts(string userId);

        (bool productsAreBoth, string error) BuyProductFromCart(string userID);

    }
}

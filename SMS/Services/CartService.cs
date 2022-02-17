using Sms.Data.Common;
using SMS.Contracts;
using SMS.Data.Models;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository repo;

        public CartService(IRepository _repo)
        {

            repo = _repo;
        }
        public (bool productIsAddedToCart, string error) AddProductToCart(string productId, string userID)
        {
            bool productIsAddedToCart = false;
            string error = null;

            var card = repo.All<Cart>().Where(c => c.User.Id == userID).FirstOrDefault();

            var product = repo.All<Product>().Where(p => p.Id == productId).FirstOrDefault();

            if (card == null || product == null)
            {
                error = "Not existing card or/and product";
                return (productIsAddedToCart, error);
            }


            try
            {

                product.Card = card;
                repo.SaveChanges();
                productIsAddedToCart = true;
            }
            catch (Exception)
            {
                error = "Could not Add product to cart";
            }


            return (productIsAddedToCart, error);
        }

        public (bool productsAreBoth, string error) BuyProductFromCart(string userID)
        {
            bool productsAreBoth = false;
            string error = null;

            var user = repo.All<User>().FirstOrDefault(u=>u.Id==userID);

            try
            {
                var products = repo.All<Product>().Where(p => p.Card.Id == user.CardId).ToList();

               foreach (var product in products)
                {
                    repo.Delete(product);
                }
               repo.SaveChanges();
                productsAreBoth = true;
            }
            catch (Exception)
            {

                error = "Unsucssesfull operation";
            }
            return(productsAreBoth, error);
        }

        public IEnumerable<CartListProductsViewModel> GetAllCartProducts(string userId)
        {
            var user = repo.All<User>().FirstOrDefault(u => u.Id == userId);

            return repo.All<Product>()
                .Where(p => p.Card.Id == user.CardId)
                .Select(p => new CartListProductsViewModel
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("F2")
                })
                .ToList();
        }
    }
}

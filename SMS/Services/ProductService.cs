using Sms.Data.Common;
using SMS.Contracts;
using SMS.Data.Models;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly IValidationService validationService;
        private readonly IRepository repo;

        public ProductService(IValidationService _validationService,
            IRepository _repo)
        {
            validationService = _validationService;
            repo = _repo;
        }
        public (bool isRepoAddedToDB, string error) AddProduct(ProductAddViewModel model)
        {
            var isRepoAddedToDB = false;
            string error = null;

            var (isValid,validationError)=validationService.ValidateModel(model);

            if (!isValid)
            {
                return(isValid,validationError);
            }

            Product product = new Product()
            {
                Name=model.Name,
                Price=model.Price
            };

            try
            {
                repo.Add(product);
                repo.SaveChanges();
                isRepoAddedToDB = true;
            }
            catch (Exception)
            {
                error = "Could not save user in DB";
            }
            return (isRepoAddedToDB, error);
        }
               
        public IEnumerable<ProductViewModel> GetProducts()
        {
            return repo.All<Product>()
                .Select(p=>new ProductViewModel
                {
                    ProductId = p.Id,
                    ProductName=p.Name,
                    ProductPrice = p.Price.ToString("F2"),
                   
                }).ToList();
        }
    }
}

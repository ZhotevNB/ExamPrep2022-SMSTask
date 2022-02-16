using Sms.Data.Common;
using SMS.Contracts;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly IValidationService validationService;
        private readonly IRepository repository;

        public ProductService(IValidationService _validationService,
            IRepository _repository)
        {
            validationService = _validationService;
            repository = _repository;
        }
        public (bool registered, string error) AddProduct(ProductAddViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}

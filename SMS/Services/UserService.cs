using Sms.Data.Common;
using SMS.Contracts;
using SMS.Data.Models;
using SMS.Models;
using System;
using System.Linq;

namespace SMS.Services
{
    public class UserService : IUserService
    {
        private readonly IValidationService validationServices;
        private readonly IRepository repo;
        private readonly IPasswordHasher passwordHasher;

        public UserService(
           IValidationService _validationServices,
           IRepository _repo,
           IPasswordHasher _passwordHasher )
        {
            validationServices = _validationServices;
            passwordHasher = _passwordHasher;
            repo = _repo;
        }
        public string GetUsername(string userId)
        {
            return repo.All<User>()
                .FirstOrDefault(u => u.Id == userId)?.Username;
        }

        public string Login(LoginFormModel model)
        {
            var user = repo.All<User>()
                .Where(u => u.Username == model.Username)
                .Where(u => u.Password == passwordHasher.HashPassword(model.Password))
                .SingleOrDefault();

            return user?.Id;
        }
        public (bool registered, string error) Register(RegisterFormModel model)
        {
            bool registered = false;
            string error = null;

            var(isValid,validationError)=validationServices.ValidateModel(model);

            if (!isValid)
            {
                return (isValid,validationError);
            }
            Card cart = new Card();
            User user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Card =cart,
                Password=passwordHasher.HashPassword(model.Password)
                
            };
            try
            {
                repo.Add(user);
                repo.SaveChanges();
                registered = true;
            }
            catch (Exception)
            {
                error = "Could not save user in DB";
            }
            return (registered, error);
        }
    }
}

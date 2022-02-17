namespace SMS
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Sms.Data.Common;
    using SMS.Contracts;
    using SMS.Data;
    using SMS.Services;

    public class StartUp
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IValidationService, ValidationService>()
                    .Add<IRepository, Repository>()
                    .Add<IUserService, UserService>()
                    .Add<IProductService, ProductService>()
                    .Add<ICartService,CartService>()
                    .Add<IPasswordHasher, PasswordHasher>()
                    .Add<SMSDbContext>())
                .WithConfiguration<SMSDbContext>(c => c.Database.MigrateAsync())

                .Start();
    }
}
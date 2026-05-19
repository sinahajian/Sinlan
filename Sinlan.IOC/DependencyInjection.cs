using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Sinlan.Application.IServices.Auth;
using Sinlan.Application.IServices.UserWords;
using Sinlan.Application.Services.Auth;
using Sinlan.Application.Services.UserWords;
using Sinlan.Data.Context;
using Sinlan.Data.Repository;
using Sinlan.Domain.IRepository;
using Sinlan.Infrastructure.Helper;
using Sinlan.Infrastructure.Security;
namespace Sinlan.IOC;

public static class DependencyInjection
{
    public static IServiceCollection AddSinlanServices(this IServiceCollection services)
    {

        services.AddSingleton<IMongoClient, MongoClient>(provider =>
        {
            var connectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING") ?? "mongodb://localhost:27017";
            return new MongoClient(connectionString);
        });



        services.AddScoped<ISinLanContext, SinLanContext>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserWordProgressRepository, UserWordProgressRepository>();
        services.AddScoped<IWordGroupRepository, WordGroupRepository>();
        services.AddScoped<IWordRepository, WordRepository>();


        //Application
        // Helper
        services.AddSingleton<IClock, Clock>();
        // Auth
        services.AddScoped<ILoginUserService, LoginUserService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IRegisterUserService, RegisterUserService>();
        // UserWords
        services.AddScoped<IAddUserWordService, AddUserWordService>();
        services.AddScoped<IAddWordsByGroupService, AddWordsByGroupService>();
        services.AddScoped<IAddWordsByLevelService, AddWordsByLevelService>();
        services.AddScoped<IChangeWordStateService, ChangeWordStateService>();
        services.AddScoped<IGetUserReviewableWordsService, GetUserReviewableWordsService>();
        services.AddScoped<IGetUserWordsCountService, GetUserWordsCountService>();
        services.AddScoped<IGetUserWordStatsService, GetUserWordStatsService>();

        return services;
    }
}
using Domain.Contracts;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ProvaNeoApp.Extensions;

public static class ServiceExtensions
{
    public static void AddRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    public static void AddSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<ApplicationDbContext>(opts =>
        opts.UseSqlServer(configuration.GetConnectionString("SqlServer")));
}
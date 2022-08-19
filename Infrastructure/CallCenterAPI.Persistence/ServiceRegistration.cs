using CallCenterAPI.Application.CQRS.Handlers.CommandHandlers;
using CallCenterAPI.Application.Repositories.CallRecordRep;
using CallCenterAPI.Persistence.Context;
using CallCenterAPI.Persistence.Repositories.CallRecordRep;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CallCenterAPI.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<CallCenterContext>(options => options.UseNpgsql(Configurations.ConnectionString));


        serviceCollection.AddScoped<ICallRecordReadRepository, CallRecordReadRepository>();
        serviceCollection.AddScoped<ICallRecordWriteRepository, CallRecordWriteRepository>();

        serviceCollection.AddTransient<CreateCallRecordCommandHandler>();
        serviceCollection.AddMediatR(typeof(CallCenterContext));

    }
}
﻿using Microsoft.Extensions.DependencyInjection;
using TimeRegistration.TimeTracker.Infrastructure.Startup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TimeRegistration.TimeTracker.ApplicationServices.Repositories.Operations;
using TimeRegistration.TimeTracker.ApplicationServices.Repositories.TimeTracker;
using TimeRegistration.TimeTracker.Infrastructure.TimeTrackerRepository;

namespace TimeRegistration.TimeTracker.Infrastructure.Installers;

public sealed class ServiceInstaller : IDependencyInstaller
{
    public void Install(IServiceCollection serviceCollection, DependencyInstallerOptions options)
    {
        serviceCollection.AddTransient<IRunOnStartupExecution, RunOnStartupExecution>();
        AddRepositories(serviceCollection, options.Configuration);
    }

    private static void AddRepositories(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration[Constants.ConfigurationKeys.SqlDbConnectionString];

        serviceCollection.AddDbContext<TimeTrackerContext>(options => options.UseSqlServer(connectionString));

        serviceCollection.AddScoped<ITimeTrackerRepository, TimeTrackerRepository.TimeTrackerRepository>();
        serviceCollection.AddScoped<IOperationRepository, OperationRepository.OperationRepository>();
    }
}

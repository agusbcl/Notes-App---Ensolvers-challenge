using Ensolvers_Challenge.Backend.Data;
using Ensolvers_Challenge.Backend.Data.Seeds;
using Ensolvers_Challenge.Backend.Models;
using Microsoft.AspNetCore.Identity;

namespace Ensolvers_Challenge.Backend
{
    public class StartupService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public StartupService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(() =>
            {
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                DataSeeder.Init(context, userManager);
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

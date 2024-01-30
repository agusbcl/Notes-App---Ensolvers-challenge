using Ensolvers_Challenge.Frontend.Services.Interfaces;
using Ensolvers_Challenge.Frontend.Services;
using MudBlazor.Services;
using Blazored.Modal;

namespace Ensolvers_Challenge.Frontend
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddMudServices();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddBlazoredModal();
        }
    }
}

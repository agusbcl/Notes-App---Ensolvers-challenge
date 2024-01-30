using Ensolvers_Challenge.Backend.Services.Interfaces;
using Ensolvers_Challenge.Backend.Services;
using Ensolvers_Challenge.Backend.Repositories;
using Ensolvers_Challenge.Backend.Repositories.Interfaces;

namespace Ensolvers_Challenge.Backend
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program).Assembly);
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}

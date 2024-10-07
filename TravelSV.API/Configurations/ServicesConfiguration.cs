using TravelSV.API.Services;

namespace TravelSV.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IRolesService, RolesService>();
            services.AddTransient<ICommercesService, CommercesService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IReviewsService, ReviewsService>();
            services.AddTransient<IProductCategoriesService, ProductCategoriesService>();
            return services;
        }
    }
}

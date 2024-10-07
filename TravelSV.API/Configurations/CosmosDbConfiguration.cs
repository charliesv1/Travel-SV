using Microsoft.EntityFrameworkCore;
using TravelSV.API.Contexts;

namespace TravelSV.API.Configurations
{
    public static class CosmosDbConfiguration
    {
        public static WebApplicationBuilder AddCosmosDb(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TravelSvDbContext>(options => {
                options.UseCosmos(builder.Configuration["connectionstring"]!, builder.Configuration["basename"]!);
            });

            return builder;
        }
    }
}

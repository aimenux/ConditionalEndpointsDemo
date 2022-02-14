using Microsoft.FeatureManagement;

namespace _04_Way;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(config => config.Conventions.Add(new ConditionalSwaggerConvention()));

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddHttpClient<Proxy>();
        services.AddTransient<IProxy, Proxy>();

        services.AddFeatureManagement().AddFeatureFilter<ConditionalFeatureFilter>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
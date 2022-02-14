namespace _02_Way;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(config => config.Filters.Add<ConditionalActionFilterAttribute>());

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => options.DocumentFilter<ConditionalSwaggerFilter>());
        
        services.AddHttpClient<Proxy>();
        services.AddTransient<IProxy, Proxy>();
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
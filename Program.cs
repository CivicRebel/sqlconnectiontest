using Microsoft.FeatureManagement;
using sqlconnectiontest.Services;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddTransient<CourseService>();
builder.Services.AddFeatureManagement();
builder.Configuration.AddAzureAppConfiguration(options => { options.Connect("Endpoint=https://appconfigsampleapp.azconfig.io;Id=p+QX;Secret=na8OFwE0rl6fW+y/7jAUK65l8UqkgqbKpJkEBcGekF0=")
    .UseFeatureFlags()});
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default",
        pattern: "{controller=Course}/{action=Index}/{id?}");
});

app.Run();

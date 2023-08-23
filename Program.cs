using Microsoft.FeatureManagement;
using sqlconnectiontest.Services;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddTransient<CourseService>();
builder.Configuration.AddAzureAppConfiguration("Endpoint=https://appconfigsampleapp.azconfig.io;Id=p+QX;Secret=na8OFwE0rl6fW+y/7jAUK65l8UqkgqbKpJkEBcGekF0=");
builder.Services.AddFeatureManagement();
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default",
        pattern: "{controller=Course}/{action=Index}/{id?}");
});

app.Run();

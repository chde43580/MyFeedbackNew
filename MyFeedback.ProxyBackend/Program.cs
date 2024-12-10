var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();



// app.UseHttpsRedirection(); Bør køre HTTP, fordi internt i Docker-netværket, right?

// app.UseAuthorization();

// app.UseRouting(); Brug for?

app.MapReverseProxy();

app.Run();
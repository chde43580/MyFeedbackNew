using Microsoft.AspNetCore.Identity;
using MyFeedback.Infrastructure;
using MyFeedback.UI.TypedClients.Interfaces;
using MyFeedback.UI.TypedClients.Implementations;


// Database-migrationer kommandoer:

// Add-Migration [MigrationNAVN] -Context MyFeedbackContext -Project MyFeedback.DatabaseMigration
// Update-Database -Context MyFeedbackContext -Project MyFeedback.DatabaseMigration

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorizationBuilder()
    .AddPolicy(
"IsTeacher",
policyBuilder => policyBuilder
    .RequireClaim("IsTeacher"))

    .AddPolicy(
    "IsAdmin",
    policyBuilder => policyBuilder
    .RequireClaim("IsAdmin"))

   .AddPolicy(
"IsLoggedIn",
policyBuilder => policyBuilder
    .RequireAuthenticatedUser());

// Her kaldes bevidst Infrastruktur-laget inkongruent med arkitekturen - pga. det tekniske concern,
// at vores Simply.com-abonnement kun tillader �n SQL-database (ellers havde vi uddifferentieret Identity-DB, hhv. resterende data-DB
builder.Services.AddInfrastructure(builder.Configuration);


// IHTTPClientFactory
builder.Services.AddHttpClient<IExitSlipClient, ExitSlipClient>(client =>
    client.BaseAddress = new Uri(builder.Configuration["MyFeedbackBackendBaseUrl"]));

builder.Services.AddHttpClient<ILessonClient, LessonClient>(client =>
    client.BaseAddress = new Uri(builder.Configuration["MyFeedbackBackendBaseUrl"]));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Lockout.AllowedForNewUsers = true;
    options.Password.RequiredLength = 12;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
}
    )
    .AddEntityFrameworkStores<MyFeedbackContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});


builder.Services.AddRazorPages();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

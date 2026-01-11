using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AdoptieAnimale.Web.Services;
using AdoptieAnimale.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// HttpClient și ApiService
//builder.Services.AddHttpClient<IApiService, ApiService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<AuthCookieHandler>();

builder.Services.AddHttpClient<IApiService, ApiService>()
    .AddHttpMessageHandler<AuthCookieHandler>();

// Identity Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity - CONFIGURARE SIMPLĂ
builder.Services.AddDefaultIdentity<IdentityUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 3; // SIMPLU pentru test
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();